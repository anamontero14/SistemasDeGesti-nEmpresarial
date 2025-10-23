using Ejercicio1.Models.Entities;

namespace Ejercicio1.Models.DAL
{
    public class CLSListadoPersonas
    {

        /// <summary>
        /// Permite obtener una lista de todas las personas
        /// pre: none
        /// </summary>
        /// <returns></returns>
        public static List<CLSPersona> ObtenerListadoPersonas()
        {
           return new List<CLSPersona> { 
                new CLSPersona(1, "Juanito", 23, 3),
                new CLSPersona(2, "María", 12, 1),
                new CLSPersona(3, "Fernando", 11, 5),
                new CLSPersona(4, "Amanda", 46, 3)
            };
        }

        public static CLSPersona ObtenerPersonaPorPosicion(int posicionPersona) {
            return ObtenerListadoPersonas()[posicionPersona];
        }

    }
}
