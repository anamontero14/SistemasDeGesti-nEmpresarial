using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
        /// <summary>
        /// Entidad que representa una persona en el dominio
        /// </summary>
        public class Persona
        {
            #region Propiedades
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public string Foto { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public int IDDepartamento { get; set; }
            #endregion

            #region Constructores
            /// <summary>
            /// Constructor vacío
            /// </summary>
            public Persona()
            {
                this.ID = 0;
                this.Nombre = string.Empty;
                this.Apellidos = string.Empty;
                this.Telefono = string.Empty;
                this.Direccion = string.Empty;
                this.Foto = string.Empty;
                this.FechaNacimiento = DateTime.MinValue;
                this.IDDepartamento = 0;
            }

            /// <summary>
            /// Constructor con todos los parámetros
            /// </summary>
            public Persona(int id, string nombre, string apellidos, string telefono,
                          string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
            {
                this.ID = id;
                this.Nombre = nombre;
                this.Apellidos = apellidos;
                this.Telefono = telefono;
                this.Direccion = direccion;
                this.Foto = foto;
                this.FechaNacimiento = fechaNacimiento;
                this.IDDepartamento = idDepartamento;
            }
            #endregion
        }
    
}
