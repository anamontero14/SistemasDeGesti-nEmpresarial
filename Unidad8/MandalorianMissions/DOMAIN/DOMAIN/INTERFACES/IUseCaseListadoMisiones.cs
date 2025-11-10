using DOMAIN.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.INTERFACES
{
    public interface IUseCaseListadoMisiones
    {
        /// <summary>
        /// Devolverá la lista de todas las misiones filtradas por la lógica de negocio
        /// </summary>
        /// <returns></returns>
        public List<Mision> getListaMisionesFiltradas();
        /// <summary>
        /// Coge una misión por el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Mision getMisionPorID(int id);
    }
}
