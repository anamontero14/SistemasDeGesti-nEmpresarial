using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class DepartamentoRepositoryUseCase : IDepartamentoRepositoryUseCase
    {
        /// <summary>
        /// Atributo que servirá para acceder a los métodos del repostiroio de los departamentos
        /// </summary>
        private readonly IDepartamentoRepository _repositorioDepartamentos;

        /// <summary>
        /// Inyección del departamento
        /// </summary>
        /// <param name="departamentoRepository"></param>
        public DepartamentoRepositoryUseCase(IDepartamentoRepository departamentoRepository) {
            _repositorioDepartamentos = departamentoRepository;
        }

        #region MÉTODOS
        //para la vista del listado
        public List<Departamento> getListaDepartamento() { 
            return _repositorioDepartamentos.getListaDepartamentos();
        }

        //para crear un nuevo departamento
        public int crearDepartamento(Departamento departamentoNuevo) {
            return _repositorioDepartamentos.crearDepartamento(departamentoNuevo);
        }

        //para actualizar un departamento
        public int actualizarDepartamento(int idDepartamento, Departamento departamentoActualizado) {
            return _repositorioDepartamentos.actualizarDepartamento(idDepartamento, departamentoActualizado);
        }

        
        /// <summary>
        /// Método para eliminar un departamento atentdiendo al id que se le pasa
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns>Un número de filas que han sido afectadas</returns>
        public int eliminarDepartamento(int idDepartamento) {

            if (_repositorioDepartamentos.personaEnDepartamento(idDepartamento) == 0)
            {
                return _repositorioDepartamentos.eliminarDepartamento(idDepartamento);
            }
            else {
                throw new InvalidOperationException("No se puede eliminar el departamento porque tiene personas asignadas.");
            }
        }

        /// <summary>
        /// Para seleccionar un departamento por ID
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public Departamento getDepartamentoPorId(int idDepartamento)
        {
            Departamento departamentoEncontrado = _repositorioDepartamentos.getDepartamentoPorId(idDepartamento);
            return departamentoEncontrado;
        }
        #endregion
    }
}
