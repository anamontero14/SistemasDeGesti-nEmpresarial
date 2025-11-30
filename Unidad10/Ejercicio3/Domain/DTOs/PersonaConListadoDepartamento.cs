using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PersonaConListadoDepartamento
    {
        //persona
        public Persona persona { get; }
        //listado de los departamentos
        public List<Departamento> departamentos { get; }

        /// <summary>
        /// Constructor del DTO que asigna valores a los atributos
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="listadoDepartamentos"></param>
        public PersonaConListadoDepartamento(Persona persona, List<Departamento> listadoDepartamentos) {
            this.persona = persona;
            departamentos = listadoDepartamentos;
        }
    }
}
