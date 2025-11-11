using Domain.Entities;
using Domain.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PeopleRepositoryEmpty : IPeopleRepository
    {
        /// <summary>
        /// Método para agarrar todas las personas excepto que la lista de las
        /// personas en este caso estará vacía para realizar pruebas
        /// </summary>
        /// <returns></returns>
        public List<Persona> getPersonas()
        {
            return new List<Persona>
            {
            };

        }
    }
}
