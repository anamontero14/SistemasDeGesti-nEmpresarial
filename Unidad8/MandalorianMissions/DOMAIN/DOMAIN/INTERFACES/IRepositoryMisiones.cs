using DOMAIN.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.INTERFACES
{
    //interfaz del repositorio
    public interface IRepositoryMisiones
    {
        /// <summary>
        /// Método que se utilizará en todas las clases en las que se implemente la interfaz
        /// </summary>
        /// <returns></returns>
        public List<Mision> getListaMisiones();

        /// <summary>
        /// Método que devuelve una misión que se ha encontrado por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Mision getMisionPorId(int id);
    }
}
