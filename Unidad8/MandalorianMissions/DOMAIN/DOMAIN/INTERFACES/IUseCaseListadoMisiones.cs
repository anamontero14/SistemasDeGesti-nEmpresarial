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
        /// Método que devuelve una misión que se ha encontrado por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Mision getMisionPorId(int id);
    }
}
