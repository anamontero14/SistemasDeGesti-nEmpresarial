using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories.RepositoriosPersona
{
    class PersonaRepositoryEmpty : IPersonaRepository
    {
        /// <summary>
        /// Método sin parámetros que se encarga de simular una llamada
        /// a una API o BBDD. ç
        /// </summary>
        /// <returns>Una lista vacía</returns>
        private List<Persona> ListaPersonasEmpty()
        {

            return [];

        }

        /// <summary>
        /// Método que sirve para devolver un listado de personas
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas()
        {
            return ListaPersonasEmpty();
        }
    }
}
