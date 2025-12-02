using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class PersonaController : Controller
    {
        /// <summary>
        /// Atributos de la clase que sirven para utilizar los métodos del caso de uso
        /// </summary>
        private readonly IPersonaRepositoryUseCase _casoDeUsoPersona;
        private readonly IDepartamentoRepositoryUseCase _casoDeUsoDepartamento;

        /// <summary>
        /// Inyección de los repositorios
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="casoDeUsoP"></param>
        /// <param name="casoDeUsoD"></param>
        public PersonaController( IPersonaRepositoryUseCase casoDeUsoP,
            IDepartamentoRepositoryUseCase casoDeUsoD)
        {
            _casoDeUsoPersona = casoDeUsoP;
            _casoDeUsoDepartamento = casoDeUsoD;
        }

        /// <summary>
        /// Acción de mostrar la cual almacena una lista de personas con nombre de departamento
        /// y que se lo manda a la vista
        /// </summary>
        /// <returns></returns>
        public IActionResult Mostrar()
        {
            try
            {
                List<PersonaConNombreDepartamento> listaPersonas = _casoDeUsoPersona.getListaPersonasConNombreDepartamento();
                return View(listaPersonas);
            }
            catch (Exception ex) { 
                return View("Error", ex);
            }
        }

        /// <summary>
        /// Se le pasa un detalle a la vista de una persona con un id específico
        /// y se devuelve un objeto persona para poder ver sus detalles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detalle(int id)
        {
            try
            {
                PersonaConNombreDepartamento persona = _casoDeUsoPersona.getPersonaConNombreDepartamento(id);
                return View(persona);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        /// <summary>
        /// Action de crear el cuál recibe una lista de departamentos mediante viewbag
        /// para después pasarle una persona vacía a la vista
        /// </summary>
        /// <returns></returns>
        public IActionResult Crear()
        {
            try
            {
                ViewBag.ListaDepartamentos = _casoDeUsoDepartamento.getListaDepartamento();
                return View(new Persona());
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        /// <summary>
        /// Action post de crear que llama al caso de uso para crear esa nueva persona
        /// y añadirla a la BBDD, después se vuelve a llamar al caso de uso donde se recibe
        /// la lista de las personas actualizadas (con la persona añadida) y finalmente
        /// se le manda a la vista Mostrar la lista de personas con la nueva persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>La vista mostrar con el listado con la persona añadida</returns>
        [HttpPost]
        public IActionResult Crear(Persona persona)
        {
            try
            {
                _casoDeUsoPersona.crearPersona(persona);
                List<PersonaConNombreDepartamento> listaPersonas = _casoDeUsoPersona.getListaPersonasConNombreDepartamento();
                return View("Mostrar", listaPersonas);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        /// <summary>
        /// El Action de editar que recibe un id para modificar una persona en específico
        /// donde también se crea un nuevo objeto del tipo persona que es igualado a la perosna
        /// que encuentra el caso de uso con el método de encontrar una persona por el id indicado,
        /// seguidamente se crea un objeto del dto que se tiene que mostrar con la persona que se ha encontrado
        /// y se le devuelve a la vista
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Se le devuelve a la vista la persona con el listado de departamentos</returns>
        public IActionResult Editar(int id)
        {
            try
            {
                Persona personaEncontrada = _casoDeUsoPersona.getPersonaPorId(id);
                PersonaConListadoDepartamento personaConListadoDepartamentoEncontrada =
                    _casoDeUsoPersona.getPersonaConListadoDepartamento(personaEncontrada);
                return View(personaConListadoDepartamentoEncontrada);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost]
        public IActionResult Editar(PersonaConListadoDepartamento personaConListado)
        {
            //se abre el try catch
            try
            {
                //se llama al caso de uso para actualizar a la persona
                _casoDeUsoPersona.actualizarPersona(personaConListado.persona.ID, personaConListado.persona);

                //se obtiene la lista de las personas actualizadas
                List<PersonaConNombreDepartamento> listaPersonas =
                    _casoDeUsoPersona.getListaPersonasConNombreDepartamento();

                //se llama a la vista mostrar
                return View("Mostrar", listaPersonas);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }


        /// <summary>
        /// Action eliminar que recibe un id de la persona a eliminar (el cuál se le pasa cuando en la vista
        /// se hace click sobre el botón eliminar de la persona) y que después lo utiliza para crear un objeto
        /// dto de personaConNombreDepartamento llamando al caso de uso en el proceso, cuando la obtiene llama
        /// de nuevo a la vista (post) con la persona que se ha obtenido.
        /// Si hubiera alguina excepción esta la atraparía el try catch y se volvería a la vista
        /// mostrar con la lista de las personas actualizadas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Eliminar(int id)
        {
            try
            {
                // Obtener la persona para mostrar sus datos en la confirmación
                PersonaConNombreDepartamento persona = _casoDeUsoPersona.getPersonaConNombreDepartamento(id);
                return View(persona);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        /// <summary>
        /// En el post lo que ocurre es que se le pasa otra vez el id una vez que confirma la eliminación de una
        /// persona para llamar al caso de uso (dentro del try catch) y a su vez lllama a eliminar persona
        /// el cuál necesita este id para eliminar a la persona de la BBDD, después almacena la lista de las
        /// personas en una variable para después mandarle la lista actualizada a la vista mostrar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Eliminar")]
        public IActionResult EliminarPost(int id)
        {
            try
            {
                _casoDeUsoPersona.eliminarPersona(id);

                List<PersonaConNombreDepartamento> listaPersonas = _casoDeUsoPersona.getListaPersonasConNombreDepartamento();

                return View("Mostrar", listaPersonas);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
