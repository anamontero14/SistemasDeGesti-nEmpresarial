namespace Ejercicio3.Models
{
    public class CLSPersona
    {
        #region ATRIBUTOS
        private string _nombre;
        private string _apellido;
        private int _edad;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor con todos los parámetros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        public CLSPersona(string nombre, string apellido, int edad) {
            _nombre = nombre;
            _apellido = apellido;
            _edad = edad;
        }
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public CLSPersona() { }
        #endregion

        #region GETTERS Y SETTERS
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
        public String apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                //el nombre se settea al valor que se le indica
                _apellido = value;
            }
        }

        public int edad
        {
            get
            {
                return _edad;
            }
            set
            {
                //el nombre se settea al valor que se le indica
                _edad = value;
            }
        }
        #endregion
    }
}
