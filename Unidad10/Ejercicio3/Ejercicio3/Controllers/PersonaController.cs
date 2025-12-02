using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCase;
using Ejercicio3.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class PersonaController : Controller
    {

        private readonly ILogger<PersonaController> _logger;
        private readonly IPersonaRepositoryUseCase _casoDeUsoPersona;
        private readonly IDepartamentoRepositoryUseCase _casoDeUsoDepartamento;

        public PersonaController(ILogger<PersonaController> logger, IPersonaRepositoryUseCase casoDeUsoP,
            IDepartamentoRepositoryUseCase casoDeUsoD)
        {
            _logger = logger;
            _casoDeUsoPersona = casoDeUsoP;
            _casoDeUsoDepartamento = casoDeUsoD;
        }

        public IActionResult Mostrar()
        {
            List<PersonaConNombreDepartamento> listaPersonas = _casoDeUsoPersona.getListaPersonasConNombreDepartamento();

            return View(listaPersonas);
        }

        public IActionResult Detalle(int id)
        {
            PersonaConNombreDepartamento persona = _casoDeUsoPersona.getPersonaConNombreDepartamento(id);

            return View(persona);
        }

        public IActionResult Crear()
        {
            // Obtener todos los departamentos para el dropdown
            List<Departamento> listaDepartamentos = _casoDeUsoDepartamento.getListaDepartamento();

            // Pasar la lista a la vista a través de ViewBag o ViewModel
            ViewBag.ListaDepartamentos = listaDepartamentos;

            // Devolver la vista con un objeto Persona vacío (opcional)
            return View(new Persona());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _casoDeUsoPersona.crearPersona(persona);

                return RedirectToAction("Mostrar");
            }

            ViewBag.ListaDepartamentos = _casoDeUsoDepartamento.getListaDepartamento();
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearPost(IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Editar(int id)
        {

            Persona personaEncontrada = _casoDeUsoPersona.getPersonaPorId(id);

            PersonaConListadoDepartamento personaConListadoDepartamentoEncontrada =
                _casoDeUsoPersona.getPersonaConListadoDepartamento(personaEncontrada);

            return View(personaConListadoDepartamentoEncontrada);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(PersonaConListadoDepartamento personaConListado)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Llamar al caso de uso para actualizar la persona
                    _casoDeUsoPersona.actualizarPersona(personaConListado.persona);

                    // Redirigir a la lista de personas
                    return RedirectToAction("Mostrar");
                }
                catch (Exception ex)
                {
                    // Opcional: agregar mensaje de error
                    ModelState.AddModelError("", "Error al actualizar la persona: " + ex.Message);
                }
            }

            // Si falla, recargar la lista de departamentos para el dropdown
            personaConListado.departamentos = _casoDeUsoDepartamento.getListaDepartamento();
            return View(personaConListado);
        }


        // GET: PersonaController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
