using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCase;

namespace Domain.UseCases
{
    public class PersonaRepositoryUseCase : IPersonaRepositoryUseCase
    {
        //instancia un objeto de tipo de la interfaz persona repository privado
        private readonly IPersonaRepository _repositorioPersonas;
        private readonly IDepartamentoRepository _repositorioDepartamentos;

        #region CONSTRUCTOR CON LA INYECCIÓN
        public PersonaRepositoryUseCase(IPersonaRepository personaRepository,
            IDepartamentoRepository departamentoRepository)
        {
            _repositorioPersonas = personaRepository;
            _repositorioDepartamentos = departamentoRepository;
        }
        #endregion

        #region MÉTODOS
        //para la vista de todas las personas
        public List<PersonaConNombreDepartamento> getListaPersonasConNombreDepartamento()
        {
            //objeto de lista la clase del dto
            List<PersonaConNombreDepartamento> listaPersonasConNombreDepartamento = null;
            //objeto de la clase dto
            PersonaConNombreDepartamento personaConNombreDepartamento;

            foreach (Persona persona in _repositorioPersonas.getListaPersonas())
            {
                //personaConNombreDepartamento = new PersonaConNombreDepartamento(persona, _repositorioDepartamentos.getListaDepartamentos());

                foreach (Departamento departamento in _repositorioDepartamentos.getListaDepartamentos())
                {
                    if (persona.IDDepartamento == departamento.ID)
                    {
                        personaConNombreDepartamento = new PersonaConNombreDepartamento(persona, departamento.Nombre);
                        listaPersonasConNombreDepartamento.Add(personaConNombreDepartamento);
                    }
                }
            }

            return listaPersonasConNombreDepartamento;
        }

        //para la vista de editar
        public PersonaConListadoDepartamento getPersonaConListadoDepartamento(Persona persona)
        {

            PersonaConListadoDepartamento personaConListadoDepartamento;

            Persona obPersona = _repositorioPersonas.getPersonaPorId(persona.ID);

            personaConListadoDepartamento = new PersonaConListadoDepartamento(obPersona, _repositorioDepartamentos.getListaDepartamentos());

            return personaConListadoDepartamento;
        }

        //para la vista de detalles
        public PersonaConNombreDepartamento getPersonaConNombreDepartamento(Persona personaEspecifica)
        {
            //objeto de la clase dto
            PersonaConNombreDepartamento personaConNombreDepartamento = null;


            foreach (Departamento departamento in _repositorioDepartamentos.getListaDepartamentos())
            {
                if (personaEspecifica.IDDepartamento == departamento.ID)
                {
                    personaConNombreDepartamento = new PersonaConNombreDepartamento(personaEspecifica, departamento.Nombre);
                }
            }


            return personaConNombreDepartamento;
        }

        //para crear la persona nueva
        public int crearPersona(Persona personaNueva) { 
           return _repositorioPersonas.crearPersona(personaNueva);
        }

        //para actualizar a una persona
        public int actualizarPersona(int idPersona, Persona personaActualizada) {
            return _repositorioPersonas.actualizarPersona(idPersona, personaActualizada);
        }

        //para eliminar a una persona
        public int eliminarPersona(int idPersona) {
            return _repositorioPersonas.eliminarPersona(idPersona);
        }
        #endregion
    }
}
