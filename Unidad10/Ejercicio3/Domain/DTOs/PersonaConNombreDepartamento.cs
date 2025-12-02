using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PersonaConNombreDepartamento
    {
        public Persona persona { get; set; }
        public string nombreDepartamento { get; set; }

        /// <summary>
        /// Constructor del DTO que le asigna a los atributos los parámetros que le pasa 
        /// el caso de uso
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="nombreDepartamento"></param>
        public PersonaConNombreDepartamento(Persona persona, string nombreDepartamento) { 
            this.persona = persona;
            this.nombreDepartamento = nombreDepartamento;
        }

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public PersonaConNombreDepartamento() { 
            persona = new Persona();
            nombreDepartamento = "";
        }
    }
}
