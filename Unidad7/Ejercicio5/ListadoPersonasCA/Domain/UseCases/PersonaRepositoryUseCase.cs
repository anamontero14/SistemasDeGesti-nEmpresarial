using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;

namespace Domain.UseCases
{
    public class PersonaRepositoryUseCase : IPersonaRepositoryUseCase
    {
        //instancia un objeto de tipo de la interfaz persona repository privado
        private readonly IPersonaRepository _listaPersonaRepository;

        //el constructor obtendrá un objeto de persona repository que será igualada
        //al objeto creado
        public PersonaRepositoryUseCase(IPersonaRepository personaRepository) { 
            _listaPersonaRepository = personaRepository;
        }

        public List<Persona> getListaPersonas() {
            //se crea una nueva lista de personas
            List<Persona> personasFiltradas = new List<Persona>();

            //se itera sobre el listado de las personas
            foreach (Persona persona in _listaPersonaRepository.getListaPersonas()) {
                if (persona.Edad <= 18) {
                    personasFiltradas.Add(persona);
                }
            }

            //retorna la lista de las personas filtrada
            return personasFiltradas;

        }
    }
}
