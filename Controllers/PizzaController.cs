using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public static PizzaContext db = new PizzaContext();

        //CREATE
        Pizza nuovaPizza = new Pizza();

        static Pizzeria pizzeria = new Pizzeria("Bella Napoli");

        public IActionResult Index()
        {
            return View(db);
        }

        public IActionResult ShowPizza(int id)
        {
            Pizza? pizzaCercata = db.Pizze.Find(id);
            if (pizzaCercata == null)
            {
                ViewData["Titolo"] = "Pizza Not Found!";
                return View("PizzaNotFound");
            }
            else
            {
                ViewData["nomePizzeria"] = pizzeria.Nome;
                return View(pizzaCercata);
            }
        }

        //CREATE
        public IActionResult CreatePizza()
        {
            Pizza nuovaPizza = new Pizza();
            return View(nuovaPizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ValidatePizza(Pizza nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePizza", nuovaPizza);
            }

            if (nuovaPizza.formFile != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileInfo newFileInfo = new FileInfo(nuovaPizza.formFile.FileName);
                string fileName = String.Format("{0}{1}", nuovaPizza.Name, newFileInfo.Extension);
                string FullPathName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(FullPathName, FileMode.Create))
                {
                    nuovaPizza.formFile.CopyTo(stream);
                    stream.Close();
                }
                nuovaPizza.ImgPath = String.Format("{0}", fileName);
            }
            //pizzeria.addPizza(nuovaPizza);
            db.Add(nuovaPizza);
            db.SaveChanges();
            return View("ShowPizza", nuovaPizza);
        }

        //VIEW DELLA UPDATE
        [HttpGet]
        public IActionResult UpdatePizza(int id)
        {
            Pizza? pizzaDaModificare = db.Pizze.Find(id);
            if (pizzaDaModificare == null)
            {
                ViewData["Titolo"] = "Pizza Not Found!";
                return View("PizzaNotFound");
            }
            else
            {
                ViewData["nomePizzeria"] = pizzeria.Nome;
                return View(pizzaDaModificare);
            }
        }

        //METODO PER UPDATARE LE PIZZE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza modello)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdatePizza", modello);
            }

            Pizza? pizzaDaModificare = db.Pizze.Find(id);

            if (pizzaDaModificare != null)
            {
                //aggiorniamo i campi con i nuovi valori
                pizzaDaModificare.Name = modello.Name;
                pizzaDaModificare.Description = modello.Description;
                pizzaDaModificare.Price = modello.Price;

                //UPDATE FOTO
                //string pathUpdate = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img");
                //string FullPathNameUpdate = Path.Combine(pathUpdate, modello.ImgPath);
                //using (FileStream streamUpdate = new FileStream(FullPathNameUpdate, FileMode.Create))
                //{
                //    pizzaDaModificare.formFile.CopyTo(streamUpdate);
                //    streamUpdate.Close();
                //}
                //pizzaDaModificare.ImgPath = modello.ImgPath;
            }
            else
            {
                ViewData["Titolo"] = "Pizza Not Found!";
                return View("PizzaNotFound");
            }

            db.SaveChanges();
            return RedirectToAction("ShowPizza", pizzaDaModificare);
        }


        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Pizza? pizzaDaRimuovere = db.Pizze.Find(id);

            db.Pizze.Remove(pizzaDaRimuovere);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
 