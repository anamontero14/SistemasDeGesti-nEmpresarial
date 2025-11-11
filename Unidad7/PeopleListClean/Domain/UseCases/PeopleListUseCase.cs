using Domain.Entities;
using Domain.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class PeopleListUseCase : IPeopleListUseCase
    {
        //se crea una variable que almacenara el listado de las personas
        private readonly IPeopleRepository _peopleListRepository;

        //Inyectamos en el constructor el repositorio
        public PeopleListUseCase(IPeopleRepository peopleRepository)
        {
            _peopleListRepository = peopleRepository;
        }

        /// <summary>
        /// Método que se implementa de la interfaz
        /// </summary>
        /// <returns></returns>
        public List<Persona> getPersonasFiltradas() {

            List<Persona> personasFiltradas = new List<Persona>();

            foreach (Persona persona in _peopleListRepository.getPersonas()) {

                if (persona.Edad > 18) {
                    personasFiltradas.Add(persona);
                }

            }

            return personasFiltradas;

        }

    }
}
