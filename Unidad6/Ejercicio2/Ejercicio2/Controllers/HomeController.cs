using System.Diagnostics;
using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers
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
            //coge la fecha actual del sistema
            DateTime horaActual = DateTime.Now;

            //determina si la hora es antes o despu�s del mediod�a
            string medioDiaOno = horaActual.Hour < 12 ? "antes del mediod�a" : "despu�s del mediod�a";

            ViewData["Hora"] = horaActual.ToString("HH:mm");
            ViewData["Periodo"] = medioDiaOno;

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
