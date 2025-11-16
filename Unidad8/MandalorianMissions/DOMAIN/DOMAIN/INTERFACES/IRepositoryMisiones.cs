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
    }
}
