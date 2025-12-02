using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.UseCase
{
    /// <summary>
    /// Caso de uso que maneja la lógica de negocio relacionada con Personas
    /// </summary>
    public class PersonaRepositoryUseCase : IPersonaRepositoryUseCase
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IDepartamentoRepository _departamentoRepository;

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor que inyecta las dependencias de los repositorios
        /// </summary>
        /// <param name="personaRepository">Repositorio de personas</param>
        /// <param name="departamentoRepository">Repositorio de departamentos</param>
        public PersonaRepositoryUseCase(IPersonaRepository personaRepository, IDepartamentoRepository departamentoRepository)
        {
            _personaRepository = personaRepository;
            _departamentoRepository = departamentoRepository;
        }
        #endregion

        #region MÉTODOS DE LA INTERFAZ

        /// <summary>
        /// Método que devuelve una lista de todas las personas
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas() { 
            return _personaRepository.getListaPersonas();
        }

        /// <summary>
        /// Obtiene una lista de personas con el nombre de su departamento
        /// </summary>
        /// <returns>Lista de PersonaConNombreDepartamento</returns>
        public List<PersonaConNombreDepartamento> getListaPersonasConNombreDepartamento()
        {
            List<PersonaConNombreDepartamento> listaPersonasConDepartamento = new List<PersonaConNombreDepartamento>();

            try
            {
                // Obtener todas las personas
                List<Persona> listaPersonas = _personaRepository.getListaPersonas();

                // Obtener todos los departamentos
                List<Departamento> listaDepartamentos = _departamentoRepository.getListaDepartamentos();

                // Crear el DTO para cada persona
                foreach (Persona persona in listaPersonas)
                {
                    PersonaConNombreDepartamento personaConDepartamento = new PersonaConNombreDepartamento();

                    Departamento departamento = new Departamento();

                    // Asignar los datos de la persona
                    personaConDepartamento.persona.ID = persona.ID;
                    personaConDepartamento.persona.Nombre = persona.Nombre;
                    personaConDepartamento.persona.Apellidos = persona.Apellidos;
                    personaConDepartamento.persona.Edad = persona.Edad;
                    personaConDepartamento.persona.FechaNacimiento = persona.FechaNacimiento;
                    personaConDepartamento.persona.Direccion = persona.Direccion;
                    personaConDepartamento.persona.Telefono = persona.Telefono;
                    personaConDepartamento.persona.IDDepartamento = persona.IDDepartamento;
                    personaConDepartamento.persona.Foto = persona.Foto;

                    foreach (Departamento dep in listaDepartamentos)
                    {
                        if (dep.ID == persona.IDDepartamento)
                        {
                            departamento = dep;
                        }
                    }

                    personaConDepartamento.nombreDepartamento = departamento.Nombre;

                    listaPersonasConDepartamento.Add(personaConDepartamento);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaPersonasConDepartamento;
        }

        /// <summary>
        /// Obtiene una persona por su ID
        /// </summary>
        /// <param name="idPersona">ID de la persona a buscar</param>
        /// <returns>Objeto Persona</returns>
        public Persona getPersonaPorId(int idPersona)
        {
            try
            {
                return _personaRepository.getPersonaPorId(idPersona);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene una persona específica con el listado completo de departamentos disponibles
        /// </summary>
        /// <param name="persona">Persona a incluir en el DTO</param>
        /// <returns>PersonaConListadoDepartamento</returns>
        public PersonaConListadoDepartamento getPersonaConListadoDepartamento(Persona persona)
        {
            // Aseguramos que la lista de departamentos nunca sea null
            List<Departamento> listaDepartamentos = _departamentoRepository.getListaDepartamentos();

            // Devolvemos directamente el DTO
            return new PersonaConListadoDepartamento(persona, listaDepartamentos);
        }


        /// <summary>
        /// Obtiene una persona específica con el nombre de su departamento
        /// </summary>
        /// <param name="personaEspecifica">Persona a convertir en DTO</param>
        /// <returns>PersonaConNombreDepartamento</returns>
        public PersonaConNombreDepartamento getPersonaConNombreDepartamento(int idPersona)
        {
            PersonaConNombreDepartamento personaConDepartamento = new PersonaConNombreDepartamento();

            try
            {
                // Obtener la persona a partir del ID
                Persona personaEspecifica = _personaRepository.getPersonaPorId(idPersona);

                // Asignar los datos de la persona
                personaConDepartamento.persona.ID = personaEspecifica.ID;
                personaConDepartamento.persona.Nombre = personaEspecifica.Nombre;
                personaConDepartamento.persona.Apellidos = personaEspecifica.Apellidos;
                personaConDepartamento.persona.Edad = personaEspecifica.Edad;
                personaConDepartamento.persona.FechaNacimiento = personaEspecifica.FechaNacimiento;
                personaConDepartamento.persona.Direccion = personaEspecifica.Direccion;
                personaConDepartamento.persona.Telefono = personaEspecifica.Telefono;
                personaConDepartamento.persona.IDDepartamento = personaEspecifica.IDDepartamento;
                personaConDepartamento.persona.Foto = personaEspecifica.Foto;

                // Obtener el nombre del departamento
                Departamento departamento = _departamentoRepository.getDepartamentoPorId(personaEspecifica.IDDepartamento);

                // Si no existe el departamento, asignar un nombre por defecto
                personaConDepartamento.nombreDepartamento = departamento != null ? departamento.Nombre : "Sin Departamento";
            }
            catch (Exception)
            {
                throw;
            }

            return personaConDepartamento;
        }


        /// <summary>
        /// Crea una nueva persona en la base de datos
        /// </summary>
        /// <param name="personaNueva">Persona a crear</param>
        /// <returns>Número de filas afectadas</returns>
        public int crearPersona(Persona personaNueva)
        {
            try
            {
                return _personaRepository.crearPersona(personaNueva);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza una persona existente en la base de datos
        /// </summary>
        /// <param name="idPersona">ID de la persona a actualizar</param>
        /// <param name="personaActualizada">Objeto persona con los nuevos datos</param>
        /// <returns>Número de filas afectadas</returns>
        public int actualizarPersona(int idPersona, Persona personaActualizada)
        {
            try
            {
                return _personaRepository.actualizarPersona(idPersona, personaActualizada);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina una persona de la base de datos
        /// </summary>
        /// <param name="idPersona">ID de la persona a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        public int eliminarPersona(int idPersona)
        {
            try
            {
                return _personaRepository.eliminarPersona(idPersona);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}