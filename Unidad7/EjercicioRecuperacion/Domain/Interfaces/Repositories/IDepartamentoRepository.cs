using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que define el contrato para el repositorio de Departamentos
    /// </summary>
    public interface IDepartamentoRepository
    {
        /// <summary>
        /// Obtiene todos los departamentos de la base de datos
        /// </summary>
        /// <returns>Lista con todos los departamentos</returns>
        List<Departamento> getAllDepartamentos();

        /// <summary>
        /// Obtiene un departamento específico por su ID
        /// </summary>
        /// <param name="id">ID del departamento a buscar</param>
        /// <returns>El departamento encontrado o null si no existe</returns>
        Departamento getDepartamentoById(int id);
    }
}