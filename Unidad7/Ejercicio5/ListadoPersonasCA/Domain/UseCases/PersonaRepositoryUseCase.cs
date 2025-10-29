using Domain.Entities;
using Domain.Interfaces;

namespace Domain.UseCases
{
    public class PersonaRepositoryUseCase : IPersonaRepositoryUseCase
    {
        public List<Persona> getListaPersonas() {
            //creo e inicializo una lista de personas que contendrá solo a personas mayores de edad
            List<Persona> listaPersonasMayoresEdad = new List<Persona>(); ;

            //se inyecta la interfaz IPersonaRepository y se itera sobre el listado
            foreach (Persona persona in getListaPersonas()) {
                if (persona.Edad >= 18) { 
                    listaPersonasMayoresEdad.Add(persona);
                }
            }

            //retorna la lista de las personas filtrada
            return listaPersonasMayoresEdad;

        }
    }
}
