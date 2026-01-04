using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;
using System.Linq;

namespace Domain.UseCases
{
    /// <summary>
    /// Caso de uso para gestionar las operaciones relacionadas con Personas
    /// </summary>
    public class UseCasePersona : IUseCasePersona
    {
        #region Propiedades
        private readonly IPersonaRepository _personaRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor con inyección de dependencias de los repositorios
        /// </summary>
        public UseCasePersona(IPersonaRepository personaRepository,
                             IDepartamentoRepository departamentoRepository)
        {
            _personaRepository = personaRepository;
            _departamentoRepository = departamentoRepository;
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Obtiene todas las personas con la lista completa de departamentos disponibles
        /// </summary>
        /// <returns>Lista de DTOs con personas y departamentos</returns>
        public List<PersonaConListaDepartamentos> getPersonas()
        {
            List<PersonaConListaDepartamentos> listaPersonasConDepartamentos = new List<PersonaConListaDepartamentos>();
            List<Persona> todasLasPersonas = _personaRepository.getAllPersonas();
            List<Departamento> todosDepartamentos = _departamentoRepository.getAllDepartamentos();

            foreach (Persona persona in todasLasPersonas)
            {
                PersonaConListaDepartamentos personaDTO = new PersonaConListaDepartamentos(
                    persona.Nombre,
                    persona.Apellidos,
                    todosDepartamentos
                );

                listaPersonasConDepartamentos.Add(personaDTO);
            }

            return listaPersonasConDepartamentos;
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Obtiene una persona específica por su ID
        /// </summary>
        /// <param name="idPersonaSeleccionada">ID de la persona a buscar</param>
        /// <returns>La persona encontrada</returns>
        private Persona getPersonaById(int idPersonaSeleccionada)
        {
            return _personaRepository.getPersonaById(idPersonaSeleccionada);
        }
        #endregion
    }
}