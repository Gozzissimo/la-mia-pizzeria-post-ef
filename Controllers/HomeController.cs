using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //INIZIO SEZIONE PIZZE
            //--------------------------------
            //ViewData["Title"] = "Pizzeria Bella Genova";

            //ViewData["MargheritaTitle"] = "Margherita";
            //ViewData["DiavolaTitle"] = "Diavola";
            //ViewData["CapricciosaTitle"] = "Capricciosa";
            //ViewData["AmericanaTitle"] = "Americana";
            //ViewData["SalsFriaTitle"] = "Salsiccia e Friarielli";

            //ViewData["MargheritaDesc"] = "Pomodori, Mozzarella, Basilico, Olio EVO";
            //ViewData["DiavolaDesc"] = "Pomodori, Mozzarella, Salame Piccante, Olio EVO Piccante";
            //ViewData["CapricciosaDesc"] = "Pomodori, Mozzarella, Prosciutto Cotto, Funghi, Olive, Carciofini";
            //ViewData["AmericanaDesc"] = "Pomodori, Mozzarella, Wurstel, Patatine Fritte";
            //ViewData["SalsFriaDesc"] = "Mozzarella, Salsiccia, Friarielli";

            //ViewData["MargheritaPrezzo"] = "4.50";
            //ViewData["DiavolaPrezzo"] = "5.00";
            //ViewData["CapricciosaPrezzo"] = "6.50";
            //ViewData["AmericanaPrezzo"] = "7.50";
            //ViewData["SalsFriaPrezzo"] = "7.00";

            //ViewData["MargheritaImg"] = "img\\margherita.jpg";
            //ViewData["DiavolaImg"] = "img\\diavola.jpg";
            //ViewData["CapricciosaImg"] = "img\\capricciosa.jpg";
            //ViewData["AmericanaImg"] = "img\\americana.jpg";
            //ViewData["SalsFriaImg"] = "img\\salsiccia-friarielli.jpg";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}