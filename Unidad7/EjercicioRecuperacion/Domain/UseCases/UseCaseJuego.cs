using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System.Collections.Generic;
using System.Linq;

namespace Domain.UseCases
{
    /// <summary>
    /// Caso de uso para gestionar la lógica del juego de adivinar departamentos
    /// </summary>
    public class UseCaseJuego : IUseCaseJuego
    {
        #region Propiedades
        private readonly IPersonaRepository _personaRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor con inyección de dependencia del repositorio de personas
        /// </summary>
        public UseCaseJuego(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Comprueba cuántos aciertos ha tenido el usuario comparando sus selecciones
        /// con los departamentos reales de las personas
        /// </summary>
        /// <param name="listaConPersonasYDepartamentos">Lista con las selecciones del usuario</param>
        /// <returns>Número total de aciertos</returns>
        public int comprobarAciertos(List<PersonaConListaDepartamentos> listaConPersonasYDepartamentos)
        {
            int contadorAciertos = 0;
            List<Persona> personasReales = _personaRepository.getAllPersonas();

            foreach (PersonaConListaDepartamentos personaDTO in listaConPersonasYDepartamentos)
            {
                Persona personaReal = personasReales.FirstOrDefault(p =>
                    p.Nombre == personaDTO.NombrePersona &&
                    p.Apellidos == personaDTO.ApellidosPersona
                );

                if (personaReal != null && personaReal.IDDepartamento == personaDTO.IdDepartamentoGuess)
                {
                    contadorAciertos++;
                }
            }

            return contadorAciertos;
        }
        #endregion
    }
}