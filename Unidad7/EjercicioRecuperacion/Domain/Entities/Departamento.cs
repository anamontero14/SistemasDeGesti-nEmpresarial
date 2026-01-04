using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
        /// <summary>
        /// Entidad que representa un departamento en el dominio
        /// </summary>
        public class Departamento
        {
            #region Propiedades
            public int ID { get; set; }
            public string Nombre { get; set; }
            #endregion

            #region Constructores
            /// <summary>
            /// Constructor vacío
            /// </summary>
            public Departamento()
            {
                this.ID = 0;
                this.Nombre = string.Empty;
            }

            /// <summary>
            /// Constructor con todos los parámetros
            /// </summary>
            public Departamento(int id, string nombre)
            {
                this.ID = id;
                this.Nombre = nombre;
            }
            #endregion
        }
    
}
