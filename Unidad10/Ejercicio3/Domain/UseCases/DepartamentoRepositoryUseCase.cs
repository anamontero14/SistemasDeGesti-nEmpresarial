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
        private readonly IDepartamentoRepository _repositorioDepartamentos;

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

        //para eliminar un departamento
        public int eliminarDepartamento(int idDepartamento) {
            return _repositorioDepartamentos.eliminarDepartamento(idDepartamento);
            //no se pueden eliminar departamentos que incluyan personas
        }

        public Departamento getDepartamentoPorId(int idDepartamento)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
