using Ejercicio1.Models.Entities;
using Ejercicio1.Models.DAL;

namespace Ejercicio1.Models.ViewModels
{
    public class Ejercicio1VM
    {

        private CLSPersona _persona;
        private List<CLSDepartamento> _departamentos;

        public Ejercicio1VM(int posicionPersona) { 
            _persona = CLSListadoPersonas.ObtenerPersonaPorPosicion(posicionPersona);
            _departamentos = CLSListadoDepartamentos.ObtenerListadoDepartamentos();
        }

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

        public static CLSListadoPersonas PersonaAleatoria(CLSListadoPersonas listadoPersonas) {

            Random rand = new Random();

            //numero random
            int numRandom = rand.Next(0, 4);

            return listadoPersonas[numRandom];
        }

    }
}
