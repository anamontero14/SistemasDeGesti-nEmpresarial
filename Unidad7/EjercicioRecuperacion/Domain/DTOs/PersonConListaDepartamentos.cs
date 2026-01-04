using Domain.Entities;
using System.Collections.Generic;

namespace Domain.DTOs
{
    /// <summary>
    /// DTO que representa una persona con la lista de departamentos disponibles
    /// y el departamento seleccionado por el usuario
    /// </summary>
    public class PersonaConListaDepartamentos
    {
        #region Propiedades
        public string NombrePersona { get; set; }
        public string ApellidosPersona { get; set; }
        public List<Departamento> ListadoDepartamentos { get; set; }
        public int IdDepartamentoGuess { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor con nombre, apellidos y lista de departamentos
        /// </summary>
        public PersonaConListaDepartamentos(string nombrePersona, string apellidosPersona,
                                           List<Departamento> listadoDepartamentos)
        {
            this.NombrePersona = nombrePersona;
            this.ApellidosPersona = apellidosPersona;
            this.ListadoDepartamentos = listadoDepartamentos;
            this.IdDepartamentoGuess = 0;
        }

        /// <summary>
        /// Constructor con todos los parámetros incluyendo el guess del usuario
        /// </summary>
        public PersonaConListaDepartamentos(string nombrePersona, string apellidosPersona,
                                           List<Departamento> listadoDepartamentos,
                                           int idDepartamentoGuess)
        {
            this.NombrePersona = nombrePersona;
            this.ApellidosPersona = apellidosPersona;
            this.ListadoDepartamentos = listadoDepartamentos;
            this.IdDepartamentoGuess = idDepartamentoGuess;
        }
        #endregion
    }
}