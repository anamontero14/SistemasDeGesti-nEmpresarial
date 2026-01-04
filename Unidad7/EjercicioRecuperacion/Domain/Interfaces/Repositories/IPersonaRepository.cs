using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define el contrato para el repositorio de Personas
    /// </summary>
    public interface IPersonaRepository
    {
        /// <summary>
        /// Obtiene todas las personas de la base de datos
        /// </summary>
        /// <returns>Lista con todas las personas</returns>
        List<Persona> getAllPersonas();

        /// <summary>
        /// Obtiene una persona específica por su ID
        /// </summary>
        /// <param name="id">ID de la persona a buscar</param>
        /// <returns>La persona encontrada o null si no existe</returns>
        Persona getPersonaById(int id);
    }
}