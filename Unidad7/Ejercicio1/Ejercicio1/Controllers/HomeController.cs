using System.Diagnostics;
using Ejercicio1.Models;
using Ejercicio1.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
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
            //variable que contendrá la fecha actual
            DateTime fecha;
            //variable que almacenará el mensaje de si es medio dia o no
            String mensaje = "";

            //instancio la entidad de persona
            CLSPersona objetoPersona = new CLSPersona(1, "Juanito", 23);

            //almaceno dicha fecha en la variable
            fecha = DateTime.Now;

            if (fecha.Hour < 12)
            {
                mensaje = "Buenos días";
            }
            else if (fecha.Hour >= 9)
            {
                mensaje = "Buenas noches";
            }
            else {
                mensaje = "Buenas tardes";
            }

            //le envio a la vista el mensaje almacenado
            ViewData["Mensaje"] = mensaje;
            //Y LA FECHA
            ViewBag.fecha = fecha;

            return View(objetoPersona);
        }

        //controla la vista del listado de personas
        public IActionResult ListadoPersonas()
        {

            //llamo a la funcion de listado personas y se la mando a la vista
            ViewBag.ListadoPersonas = new CLSListadoPersonas().ObtenerListadoPersonas();

            return View();
        }

        //controla la vista del listado de las propiedades de una persona especifica
        public IActionResult PropiedadesPersona() {
            //instancio un objeto de la clase listado personas
            List<CLSPersona> listadoPersonas = new CLSListadoPersonas().ObtenerListadoPersonas();

            //creo a la persona
            CLSPersona persona3 = listadoPersonas[2];

            //le mando a la vista la persona 3
            ViewBag.persona3 = persona3;

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
