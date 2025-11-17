using Domain.Entities;
using Domain.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        /// <summary>
        /// Método para agarrar todas las personas
        /// </summary>
        /// <returns></returns>
        public List<Persona> getPersonas()
        {
            return new List<Persona>
            {
                new Persona(1, "Juan", "Miguel", 34),
                new Persona(2, "Ana", "López", 28),
                new Persona(3, "Carlos", "Ramírez", 41),
                new Persona(4, "Lucía", "Fernández", 22),
                new Persona(5, "Pedro", "García", 37),
                new Persona(6, "María", "Sánchez", 30),
                new Persona(7, "Javier", "Torres", 45),
                new Persona(8, "Elena", "Martínez", 26)
            };

        }
    }
}
