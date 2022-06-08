using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        static Pizzeria pizzeria = new Pizzeria("Bella Napoli");

        public IActionResult Index()
        {
            return View(pizzeria.listaPizze);
        }

        public IActionResult ShowPizza(int id)
        {
            Pizza? pizzaCercata = pizzeria.listaPizze.Find(item => item.Id == id);
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
            pizzeria.addPizza(nuovaPizza);
            return View("ShowPizza", nuovaPizza);
        }

        //VIEW DELLA UPDATE
        [HttpGet]
        public IActionResult UpdatePizza(int id)
        {
            Pizza? pizzaDaModificare = pizzeria.listaPizze.Find(item => item.Id == id);
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

            Pizza? pizzaDaModificare = pizzeria.listaPizze.Find(item => item.Id == id);

            if (pizzaDaModificare != null)
            {
                //aggiorniamo i campi con i nuovi valori
                pizzaDaModificare.Name = modello.Name;
                pizzaDaModificare.Description = modello.Description;
                pizzaDaModificare.Price = modello.Price;
            }
            else
            {
                ViewData["Titolo"] = "Pizza Not Found!";
                return View("PizzaNotFound");
            }

            return RedirectToAction("ShowPizza");
        }


        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Pizza? pizzaDaRimuovere = pizzeria.listaPizze.Find(item => item.Id == id);

            pizzeria.listaPizze.Remove(pizzaDaRimuovere);
            return RedirectToAction("Index");
        }
    }
}
 