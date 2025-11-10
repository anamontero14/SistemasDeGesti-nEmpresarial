using DOMAIN.ENTITIES;
using DOMAIN.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.USECASES
{
    public class ListadoMisionesUseCase : IUseCaseListadoMisiones
    {
        //instancia un objeto de tipo de la interfaz misiones repository privado
        private readonly IRepositoryMisiones _listaMisionesRepository;

        //el constructor obtendrá un objeto de misiones repository que será igualada
        //al objeto creado
        public ListadoMisionesUseCase(IRepositoryMisiones misionRepository)
        {
            _listaMisionesRepository = misionRepository;
        }
        public List<Mision> getListaMisionesFiltradas() { 
        

        }

        public Mision getMisionPorID(int id) { 
        }
    }
}
