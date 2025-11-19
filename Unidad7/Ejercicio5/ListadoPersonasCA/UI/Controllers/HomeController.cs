using System.Diagnostics;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
        }

        public IActionResult Index([FromServices] IPersonaRepositoryUseCase casoDeUso)
        {

            return View(casoDeUso.getListaPersonas());
        }
        
        //action de vista detalles que se le manda un id de la persona a mostrar
        public IActionResult Details(int id) { 
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
