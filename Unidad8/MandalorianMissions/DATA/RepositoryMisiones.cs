using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN.ENTITIES;
using DOMAIN.INTERFACES;

namespace DATA
{
    public class RepositoryMisiones : IRepositoryMisiones
    {
        /// <summary>
        /// Lista de misiones que tiene el mandaloriano
        /// </summary>
        /// <returns></returns>
        private List<Mision> ListaMisiones()
        {

            return [
                    new Mision(1, "Rescate de Baby Yoda", "Debes hacerte con Grogu y llevárselo a Luke SkyWalker para su entrenamiento.", 5000),
                    new Mision(2, "Recuperar armadura Beskar", "Tu armadura de Beskar ha sido robada. Debes encontrarla.", 2000),
                    new Mision(3, "Planeta Sorgon", "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.", 500),
                    new Mision(4, "Renacuajos", "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.", 500)
                ];
        }

        /// <summary>
        /// Método que sirve para devolver un listado de todas las misiones
        /// </summary>
        /// <returns></returns>
        public List<Mision> getListaMisiones()
        {
            return ListaMisiones();
        }
    }
}
