using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI.Controllers
{
    public class DepartamentoController : Controller
    {
        /// <summary>
        /// Atributo que almacena el repositorio del caso de uso para poder usar sus métodos
        /// </summary>
        private readonly IDepartamentoRepositoryUseCase _casoDeUsoDepartamento;

        /// <summary>
        /// Inyección del repositorio
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="casoDeUsoP"></param>
        /// <param name="casoDeUsoD"></param>
        public DepartamentoController(
            IDepartamentoRepositoryUseCase casoDeUsoD)
        {
            _casoDeUsoDepartamento = casoDeUsoD;
        }

        /// <summary>
        /// Action de mostrar que obtiene una lista de los departamentos del caso de uso
        /// </summary>
        /// <returns>La vista con la lista de los departamentos</returns>
        public IActionResult Mostrar()
        {
            try
            {
                List<Departamento> listaDepartamentos = _casoDeUsoDepartamento.getListaDepartamento();
                return View(listaDepartamentos);
            }
            catch (Exception ex) { 
                return View("Error", ex);
            }
        }

        /// <summary>
        /// IAction de detalles donde se le pasa un id del departamento a mostrar para después
        /// llamar al caso de uso para que devuelva dicho departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La persona encontrada</returns>
        public IActionResult Detalles(int id)
        {
            try
            {
                Departamento departamento = _casoDeUsoDepartamento.getDepartamentoPorId(id);
                return View(departamento);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        /// <summary>
        /// IAction de crear para poder mostrar la vista de crear
        /// </summary>
        /// <returns>Devuelve la vista de crear</returns>
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Crear")]
        public IActionResult CrearPost(Departamento departamento)
        {
            try
            {
                _casoDeUsoDepartamento.crearDepartamento(departamento);
                List<Departamento> listaDepartamentos = _casoDeUsoDepartamento.getListaDepartamento();
                return View("Mostrar", listaDepartamentos);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        
        public IActionResult Editar(int id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Editar")]
        public IActionResult EditarPost(int id, Departamento departamentoActualizado)
        {
            try
            {
                Departamento departamentoEncontrado = _casoDeUsoDepartamento.getDepartamentoPorId(id);
                _casoDeUsoDepartamento.actualizarDepartamento(id, departamentoActualizado);
                List<Departamento> listaDepartamentos = _casoDeUsoDepartamento.getListaDepartamento();
                return View("Mostrar", listaDepartamentos);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public IActionResult Eliminar(int id)
        {
            try
            {
                // Obtener el departamento para mostrar sus datos en la confirmación
                Departamento departamento = _casoDeUsoDepartamento.getDepartamentoPorId(id);
                return View(departamento);
            }
            catch (Exception ex) { 
                return View("Error", ex);
            }
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public IActionResult EliminarPost(int id)
        {
            try
            {
                _casoDeUsoDepartamento.eliminarDepartamento(id);
                List<Departamento> listaDepartamentos = _casoDeUsoDepartamento.getListaDepartamento();
                return View("Mostrar", listaDepartamentos);
            }
            catch (InvalidOperationException ex1)
            {
                ViewBag.ErrorMessage = ex1.Message;
                return View("Error");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
