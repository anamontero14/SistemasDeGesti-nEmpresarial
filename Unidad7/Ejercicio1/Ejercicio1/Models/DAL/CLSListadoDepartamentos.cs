using Ejercicio1.Models.Entities;

namespace Ejercicio1.Models.DAL
{
    public class CLSListadoDepartamentos
    {
        /// <summary>
        /// Devuelve una lista de los departamentos existentes en el sistema
        /// pre: none
        /// </summary>
        /// <returns></returns>
        public static List<CLSDepartamento> ObtenerListadoDepartamentos() { 
            
            return new List<CLSDepartamento> {
                new CLSDepartamento(1, "Departamento 1"),
                new CLSDepartamento(2, "Departamento 2"),
                new CLSDepartamento(3, "Departamento 3"),
                new CLSDepartamento(4, "Departamento 4"),
                new CLSDepartamento(5, "Departamento 5")
            };
        }
    }
}
