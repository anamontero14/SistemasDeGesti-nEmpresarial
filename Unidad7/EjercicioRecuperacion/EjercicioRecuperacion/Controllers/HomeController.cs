using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UI.Models;

namespace UI.Controllers
{
    /// <summary>
    /// Controlador para gestionar el juego de adivinar departamentos
    /// </summary>
    public class HomeController : Controller
    {
        #region Propiedades
        private readonly IUseCasePersona _useCasePersona;
        private readonly IUseCaseJuego _useCaseJuego;
        private readonly IPersonaRepository _personaRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor con inyección de dependencias
        /// </summary>
        public HomeController(IUseCasePersona useCasePersona,
                              IUseCaseJuego useCaseJuego,
                              IPersonaRepository personaRepository,
                              IDepartamentoRepository departamentoRepository)
        {
            _useCasePersona = useCasePersona;
            _useCaseJuego = useCaseJuego;
            _personaRepository = personaRepository;
            _departamentoRepository = departamentoRepository;
        }
        #endregion

        #region Métodos de Acción
        /// <summary>
        /// Acción GET que muestra la vista inicial del juego
        /// </summary>
        /// <returns>Vista con el listado de personas</returns>
        [HttpGet]
        public IActionResult Index()
        {
            List<PersonaConListaDepartamentos> personasDTO = _useCasePersona.getPersonas();
            List<PersonaConListaDepartamentosYColor> personasConColor = convertirDTOaModelo(personasDTO);

            return View(personasConColor);
        }

        /// <summary>
        /// Acción POST que procesa las selecciones del usuario
        /// </summary>
        /// <param name="listaPersonas">Lista con las selecciones del usuario</param>
        /// <returns>Vista con el resultado del juego</returns>
        [HttpPost]
        [ActionName("Index")]
        public IActionResult PostIndex(List<PersonaConListaDepartamentosYColor> listaPersonas)
        {
            List<PersonaConListaDepartamentos> personasDTO = convertirModeloADTO(listaPersonas);
            int numeroAciertos = _useCaseJuego.comprobarAciertos(personasDTO);
            int totalPersonas = listaPersonas.Count;

            if (numeroAciertos == totalPersonas)
            {
                ViewBag.Mensaje = "¡Enhorabuena! ¡Has ganado! Has acertado todos los departamentos.";
                ViewBag.EsVictoria = true;
            }
            else
            {
                ViewBag.Mensaje = $"Has acertado {numeroAciertos} de {totalPersonas} departamentos. ¡Inténtalo de nuevo!";
                ViewBag.EsVictoria = false;
            }

            ViewBag.NumeroAciertos = numeroAciertos;
            ViewBag.TotalPersonas = totalPersonas;

            List<PersonaConListaDepartamentos> personasActualizadas = _useCasePersona.getPersonas();
            List<PersonaConListaDepartamentosYColor> personasConColor = convertirDTOaModelo(personasActualizadas);

            actualizarSeleccionesUsuario(personasConColor, listaPersonas);

            return View(personasConColor);
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Convierte una lista de DTOs del dominio a modelos de la UI con colores
        /// </summary>
        /// <param name="personasDTO">Lista de DTOs del dominio</param>
        /// <returns>Lista de modelos de UI</returns>
        private List<PersonaConListaDepartamentosYColor> convertirDTOaModelo(List<PersonaConListaDepartamentos> personasDTO)
        {
            List<PersonaConListaDepartamentosYColor> personasConColor = new List<PersonaConListaDepartamentosYColor>();
            List<Persona> personasReales = _personaRepository.getAllPersonas();

            foreach (PersonaConListaDepartamentos dto in personasDTO)
            {
                Persona personaReal = personasReales.FirstOrDefault(p =>
                    p.Nombre == dto.NombrePersona &&
                    p.Apellidos == dto.ApellidosPersona
                );

                PersonaConListaDepartamentosYColor modelo = new PersonaConListaDepartamentosYColor
                {
                    NombrePersona = dto.NombrePersona,
                    ApellidosPersona = dto.ApellidosPersona,
                    ListadoDepartamentos = dto.ListadoDepartamentos,
                    IdDepartamentoGuess = dto.IdDepartamentoGuess,
                    IdDepartamentoReal = personaReal?.IDDepartamento ?? 0,
                    Color = asignarColorPorDepartamento(personaReal?.IDDepartamento ?? 0)
                };

                personasConColor.Add(modelo);
            }

            return personasConColor;
        }

        /// <summary>
        /// Convierte una lista de modelos de UI a DTOs del dominio
        /// </summary>
        /// <param name="personasModelo">Lista de modelos de UI</param>
        /// <returns>Lista de DTOs del dominio</returns>
        private List<PersonaConListaDepartamentos> convertirModeloADTO(List<PersonaConListaDepartamentosYColor> personasModelo)
        {
            List<PersonaConListaDepartamentos> personasDTO = new List<PersonaConListaDepartamentos>();
            List<Departamento> todosDepartamentos = _departamentoRepository.getAllDepartamentos();

            foreach (PersonaConListaDepartamentosYColor modelo in personasModelo)
            {
                PersonaConListaDepartamentos dto = new PersonaConListaDepartamentos(
                    modelo.NombrePersona,
                    modelo.ApellidosPersona,
                    todosDepartamentos,
                    modelo.IdDepartamentoGuess
                );

                personasDTO.Add(dto);
            }

            return personasDTO;
        }

        /// <summary>
        /// Asigna un color específico basándose en el ID del departamento
        /// para proporcionar una pista visual al usuario
        /// </summary>
        /// <param name="idDepartamento">ID del departamento</param>
        /// <returns>Código de color hexadecimal</returns>
        private string asignarColorPorDepartamento(int idDepartamento)
        {
            string colorAsignado;

            switch (idDepartamento)
            {
                case 1:
                    colorAsignado = "#FFE6E6";
                    break;
                case 2:
                    colorAsignado = "#E6F3FF";
                    break;
                case 3:
                    colorAsignado = "#E6FFE6";
                    break;
                case 4:
                    colorAsignado = "#FFF3E6";
                    break;
                case 5:
                    colorAsignado = "#F3E6FF";
                    break;
                default:
                    colorAsignado = "#F5F5F5";
                    break;
            }

            return colorAsignado;
        }

        /// <summary>
        /// Actualiza las selecciones del usuario en la lista de personas después del POST
        /// </summary>
        /// <param name="personasDestino">Lista donde se actualizarán las selecciones</param>
        /// <param name="personasOrigen">Lista con las selecciones del usuario</param>
        private void actualizarSeleccionesUsuario(List<PersonaConListaDepartamentosYColor> personasDestino,
                                                  List<PersonaConListaDepartamentosYColor> personasOrigen)
        {
            for (int i = 0; i < personasDestino.Count && i < personasOrigen.Count; i++)
            {
                personasDestino[i].IdDepartamentoGuess = personasOrigen[i].IdDepartamentoGuess;
            }
        }
        #endregion
    }
}