using Domain.UseCases.Interfaces;
using EjercicioGuiado.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjercicioGuiado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //se le inyecta el caso de uso
        public IActionResult Index([FromServices] IPeopleListUseCase peopleListUseCase)
        {
            return View(peopleListUseCase.getPersonasFiltradas());
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
