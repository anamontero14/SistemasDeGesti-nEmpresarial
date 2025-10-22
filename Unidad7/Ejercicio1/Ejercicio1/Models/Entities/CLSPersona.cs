using System.Runtime.CompilerServices;

namespace Ejercicio1.Models.Entities
{
    public class CLSPersona
    {
        #region Atributos Privados
        //atributos que tendrá la persona
        private int _id;
        private String _nombre = "";
        private int _edad;
        private int _departamentoID;
        #endregion

        //constructor
        public CLSPersona(int id, string nombre, int edad, int departamentoId) { 
            _id = id;
            _nombre = nombre;
            _edad = edad;
            _departamentoID = departamentoId;
        }

        public CLSPersona(int id, string nombre, int edad)
        {
            _id = id;
            _nombre = nombre;
            _edad = edad;
            _departamentoID = 0;
        }


        #region Getters Y Setters
        //devuelve el id de la persona
        public int ID { 
            get { 
                return _id; 
            } 
        }

        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            { 
                //el nombre se settea al valor que se le indica
               _nombre = value; 
            }
        }

        //devuelve la edad actual de la persona
        public int edad {
            get {
                return _edad;
            }
        }

        //método get y set para el id del departamento en el que está la persona
        public int departamentoId {
            get {
                return _departamentoID;
            }

            set { 
                _departamentoID = value;
            }
        }
        #endregion
    }
}
