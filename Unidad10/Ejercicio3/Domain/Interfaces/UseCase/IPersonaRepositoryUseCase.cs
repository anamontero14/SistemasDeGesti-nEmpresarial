using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCase
{
    /// <summary>
    /// Interfaz del caso de uso que permitirá a este pueda dejar
    /// al view model acceder a sus métodos el cuál consistirá en mandarle
    /// una lista
    /// </summary>
    public interface IPersonaRepositoryUseCase
    {

        /// <summary>
        /// Método que devuelve una lista de todas las personas de la BBDD
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas();

        /// <summary>
        /// Método que sirve para darle la lista de los DTO a el controlador
        /// </summary>
        /// <returns></returns>
        public List<PersonaConNombreDepartamento> getListaPersonasConNombreDepartamento();

        /// <summary>
        /// Método que devuelve una persona buscada por su id
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public Persona getPersonaPorId(int idPersona);

        /// <summary>
        /// Método
        /// </summary>
        /// <returns></returns>
        public PersonaConListadoDepartamento getPersonaConListadoDepartamento(Persona persona);

        public PersonaConNombreDepartamento getPersonaConNombreDepartamento(int idPersona);

        public int crearPersona(Persona personaNueva);

        public int actualizarPersona(int idPersona, Persona personaActualizada);

        public int eliminarPersona(int idPersona);
    }
}
