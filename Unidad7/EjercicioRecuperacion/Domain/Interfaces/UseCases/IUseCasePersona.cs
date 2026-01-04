using Domain.DTOs;
using System.Collections.Generic;

namespace Domain.Interfaces.UseCases
{
    /// <summary>
    /// Interfaz que define el contrato para el caso de uso de Persona
    /// </summary>
    public interface IUseCasePersona
    {
        /// <summary>
        /// Obtiene la lista de personas con sus departamentos disponibles
        /// </summary>
        /// <returns>Lista de personas con departamentos</returns>
        List<PersonaConListaDepartamentos> getPersonas();
    }
}