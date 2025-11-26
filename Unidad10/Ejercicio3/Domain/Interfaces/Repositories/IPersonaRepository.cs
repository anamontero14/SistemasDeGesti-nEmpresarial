using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz de repositorio de persona que será implementada por los
    /// repositorios de la carpeta DATA para que los métodos que se encuentran
    /// dentro de estos puedan ser usados en otras clases fuera de DATA.
    /// </summary>
    public interface IPersonaRepository
    {
        /// <summary>
        /// Método que se tendrá que implementar en donde se inyecte para
        /// poder hacer uso de los métodos listado de personas
        /// de los repositorios
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas();

        /// <summary>
        /// devuelve una persona específica que proviene de la BBDD
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public Persona getPersonaPorId(int idPersona);

        /// <summary>
        /// Método que crea una nueva persona
        /// </summary>
        /// <param name="personaNueva"></param>
        /// <returns></returns>
        public int crearPersona(Persona personaNueva);

        /// <summary>
        /// Método que actualiza una persona
        /// </summary>
        /// <param name="idPersona"></param>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int actualizarPersona(int idPersona, Persona persona);

        /// <summary>
        /// Método que elimina una persona
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public int eliminarPersona(int idPersona);
    }
}
