using Domain.Entities;
using System.Collections.Generic;

namespace UI.Models
{
    /// <summary>
    /// Modelo de la capa de presentación que extiende el DTO del dominio
    /// añadiendo información de color para la interfaz de usuario
    /// </summary>
    public class PersonaConListaDepartamentosYColor
    {
        #region Propiedades
        public string NombrePersona { get; set; }
        public string ApellidosPersona { get; set; }
        public List<Departamento> ListadoDepartamentos { get; set; }
        public int IdDepartamentoGuess { get; set; }
        public string Color { get; set; }
        public int IdDepartamentoReal { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public PersonaConListaDepartamentosYColor()
        {
            this.NombrePersona = string.Empty;
            this.ApellidosPersona = string.Empty;
            this.ListadoDepartamentos = new List<Departamento>();
            this.IdDepartamentoGuess = 0;
            this.Color = string.Empty;
            this.IdDepartamentoReal = 0;
        }
        #endregion
    }
}