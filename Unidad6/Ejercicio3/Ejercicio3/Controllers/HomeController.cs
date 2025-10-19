using System.Diagnostics;
using Ejercicio3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio3.Controllers
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

            string resultado = "";
            string tabla = "<table border='1'>";

            for (int i = 1; i <= 10; i++) {

                tabla += "<tr>";

                for (int j = 1; j <= 12; j++) { 
                    
                    tabla += "<td>";
                    resultado = $"{i} x {j} = {i * j}";
                    tabla += resultado;
                    tabla += "</td>";

                }

                tabla += "</tr>";

            }

            tabla += "</table>";

            ViewData["Tabla"] = tabla;

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
