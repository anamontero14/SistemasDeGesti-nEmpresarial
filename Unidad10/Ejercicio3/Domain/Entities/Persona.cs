using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona
    {
        #region ATRIBUTOS PRIVADOS

        private int _id;
        private string _nombre;
        private string _apellidos;
        private int _edad;
        private DateTime _fechaNacimiento;
        private string _direccion;
        private string _telefono;

        #endregion

        /// <summary>
        /// Constructor de la clase persona con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="edad"></param>
        public Persona(int id, string nombre, string apellidos, int edad, DateTime fechaNacimiento, string direccion, string telefono) { 
            this._id = id;
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._edad = edad;
            this._fechaNacimiento = fechaNacimiento;
            this._direccion = direccion;
            this._telefono = telefono;
        }

        /// <summary>
        /// Constructor de la clase persona vacío
        /// </summary>
        public Persona() { }

        #region GETTERS Y SETTERS

        public int ID
        {
            get
            {
                return _id;
            }
            set {
                _id = value;
            }
        }

        public string Nombre {
            get {
                return _nombre;
            }
            set {
                _nombre = value;
            }
        }

        public string Apellidos {
            get {
                return _apellidos;
            }
            set { 
                _apellidos = value;
            }
        }

        public int Edad {
            get {
                return _edad;
            }
            set { 
                _edad = value;
            }
        }

        public DateTime FechaNacimiento {
            get {
                return _fechaNacimiento;
            }
            set { 
                _fechaNacimiento = value;  
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        #endregion
    }
}
