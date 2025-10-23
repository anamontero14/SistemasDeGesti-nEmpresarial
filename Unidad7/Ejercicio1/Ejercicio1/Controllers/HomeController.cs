using System.Diagnostics;
using Ejercicio1.Models;
using Ejercicio1.Models.Entities;
using Ejercicio1.Models.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ejercicio1.Models.ViewModels;

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
            CLSPersona objetoPersona = new CLSPersona(1, "Juanito", 23, 3);

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
            //en una variable almaceno la lista de personas que se pasa desde la clase CLSListadoPersonas
            List<CLSPersona> lista = CLSListadoPersonas.ObtenerListadoPersonas();

            //devuelve el listado de las personas
            return View(lista);
        }

        //controla la vista del listado de las propiedades de una persona especifica
        public IActionResult PropiedadesPersona() {

            //creo una variable llamada persona a la que le igualo lo que devuelva
            //el metodo obtener persona por posicion
            CLSPersona persona = CLSListadoPersonas.ObtenerPersonaPorPosicion(2);

            return View(persona);
        }

        //devuelve una persona aleatoria
        public IActionResult PersonaAzar() {

            Ejercicio1VM vm = new Ejercicio1VM();

            //le mando la persona que el vm agarra aleatoriamente de la lista de las personas
            return View(vm);
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
