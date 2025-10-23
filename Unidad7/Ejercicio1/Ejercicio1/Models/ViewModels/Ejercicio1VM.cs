using Ejercicio1.Models.Entities;
using Ejercicio1.Models.DAL;

namespace Ejercicio1.Models.ViewModels
{
    public class Ejercicio1VM
    {
        #region ATRIBUTOS PRIVADOS DE LA CLASE
        private CLSPersona _persona;
        private List<CLSDepartamento> _departamentos;
        #endregion

        /// <summary>
        /// Constructor de la clase VM
        /// </summary>
        /// <param name="posicionPersona"></param>
        public Ejercicio1VM(int posicionPersona) { 
            //al constructor le llega una posicion la cual va a entrar por parámetros
            //de la llamada estatica a la clase listado personas que llama a su vez al
            //método de obtener una persona por posicion
            _persona = CLSListadoPersonas.ObtenerPersonaPorPosicion(posicionPersona);
            //a su vez el atributo departamentos será igualado a lo que resulte de
            //llamar estáticamente a la clase CLSListadoDepartamentos y a su método
            //para obtener un listado de departamentos
            _departamentos = CLSListadoDepartamentos.ObtenerListadoDepartamentos();
        }

        #region GETTERS Y SETTERS 
        public CLSPersona persona {
            get { 
                return _persona;
            }
            set { 
                _persona = value;
            }
        }

        public List<CLSDepartamento> departamentos {
            get {
                return _departamentos;
            }
        }
        #endregion

        /// <summary>
        /// Método al que le llegará una posición para agarrar a una persona
        /// de la lista que crea y almacena en una variable llamando a la clase
        /// listado personas
        /// </summary>
        /// <param name="numPosicion"></param>
        /// <returns></returns>
        public Ejercicio1VM() {
            //crea una variable para crear un numero aleatorio
            Random rand = new Random();
            //se crea una variable que almacenará el nº aleatorio el cuál estará
            //comprendido entre 0 y el número de personas que hay en la lista de personas
            int posicionPersona = rand.Next(CLSListadoPersonas.ObtenerListadoPersonas().Count);

            //el atributo persona es igualado a la obtención de una persona
            _persona = CLSListadoPersonas.ObtenerPersonaPorPosicion(posicionPersona);

            //y el departamento es igualado a la lista de los departamentos
            _departamentos = CLSListadoDepartamentos.ObtenerListadoDepartamentos();
        }

    }
}
