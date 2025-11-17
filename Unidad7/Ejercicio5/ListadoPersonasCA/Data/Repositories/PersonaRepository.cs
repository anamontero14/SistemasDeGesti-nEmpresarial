using Domain.Entities;
using Domain.Repositories;

namespace Data.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        /// <summary>
        /// Método sin parámetros que se encarga de simular una llamada
        /// a una API o BBDD.
        /// </summary>
        /// <returns>Una lista con personas</returns>
        private List<Persona> ListaPersonas()
        {

            return [
                new Persona(1, "Juan", "Pérez", 23, new DateTime(2001, 5, 12), "Calle Falsa 123", "555-1111"),
                new Persona(2, "Ana", "García", 30, new DateTime(1994, 3, 8), "Av. Central 45", "555-2222"),
                new Persona(3, "Luis", "Martínez", 25, new DateTime(1999, 7, 20), "Calle Norte 78", "555-3333"),
                new Persona(4, "Marta", "López", 28, new DateTime(1996, 9, 15), "Paseo del Sol 12", "555-4444"),
                new Persona(5, "Carlos", "Sánchez", 40, new DateTime(1984, 1, 30), "Calle Sur 9", "555-5555"),
                new Persona(6, "Lucía", "Fernández", 22, new DateTime(2002, 11, 2), "Av. Libertad 100", "555-6666"),
                new Persona(7, "Diego", "Torres", 35, new DateTime(1989, 4, 18), "Calle Río 56", "555-7777"),
                new Persona(8, "Sofía", "Ruiz", 27, new DateTime(1997, 6, 25), "Boulevard Este 34", "555-8888"),
                new Persona(9, "Miguel", "Vargas", 31, new DateTime(1993, 2, 10), "Camino Real 5", "555-9999"),
                new Persona(10, "Elena", "Navarro", 29, new DateTime(1995, 12, 3), "Calle Jardín 77", "555-0000")
            ];


        }

        /// <summary>
        /// Método que sirve para devolver un listado de personas
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas()
        {
            return ListaPersonas();
        }
    }
}
