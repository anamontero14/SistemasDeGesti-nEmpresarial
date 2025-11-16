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
            return View();
        }

        public IActionResult Editar() { 
            CLSPersona yo = new CLSPersona("Ana", "Montero", 19);

            return View(yo);
        }

        [HttpPost]
        public IActionResult PersonaModificada(CLSPersona persona) {
            //se le pasa a la vista persona modificada la persona entera
            ViewBag.persona = persona;
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
