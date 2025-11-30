using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IDepartamentoRepository
    {
        /// <summary>
        /// Método que devuelve una lista de todos los departamentos
        /// </summary>
        /// <returns></returns>
        public List<Departamento> getListaDepartamentos();

        /// <summary>
        /// Método que devuelve un departamento en específico del que se quieren saber datos
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public Departamento getDepartamentoPorId(int idDepartamento);

        /// <summary>
        /// Método que crea un departamento nuevo en la BBDD
        /// </summary>
        /// <param name="departamentoNuevo"></param>
        /// <returns></returns>
        public int crearDepartamento(Departamento departamentoNuevo);

        /// <summary>
        /// Método que actualiza un departamento en específico de la BBDD
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public int actualizarDepartamento(int idDepartamento, Departamento departamento);

        /// <summary>
        /// Método que sirve para elminar un departamento en específico
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public int eliminarDepartamento(int idDepartamento);
    }
}
