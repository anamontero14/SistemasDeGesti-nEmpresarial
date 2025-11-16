using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.ENTITIES
{
    public class Mision
    {

        #region ATRIBUTOS
        private int _id;
        private string _nombre;
        private string _descripcion;
        private int _recompensa;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Mision() { }
        /// <summary>
        /// Constructor con todos los parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="recompensa"></param>
        public Mision(int id, string nombre, string descripcion, int recompensa) {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _recompensa = recompensa;
        }
        #endregion

        #region GETTERS Y SETTERS
        public int ID
        {
            get
            {
                return _id;
            }
        }

        public string Nombre {
            get { 
                return _nombre;
            }
            set { 
                _nombre=value;
            }
        }

        public string Descripcion {
            get {
                return _descripcion;
            }
            set { 
                _descripcion=value;
            } 
        }

        public int Recompensa {
            get {
                return _recompensa;
            }
            set { 
                _recompensa=value;
            }
        }
        #endregion

    }
}
