using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Interfaces
{
    public interface IPeopleRepository
    {

        /// <summary>
        /// Método que tendrán que usar todas las clases que implementen la interfaz 
        /// y que devolverá una lista con todas las personas
        /// </summary>
        /// <returns></returns>
        public List<Persona> getPersonas();

    }
}
