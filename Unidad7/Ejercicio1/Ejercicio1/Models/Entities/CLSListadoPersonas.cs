namespace Ejercicio1.Models.Entities
{
    public class CLSListadoPersonas
    {
        //funcion que me permitirá obtener un listado de las personas
        public List<CLSPersona> ObtenerListadoPersonas()
        {

            //instancio una nueva lista de personas
            List<CLSPersona> listaPersonas = new List<CLSPersona>();

            //añado personas a la lista
            listaPersonas.Add(new CLSPersona(1, "Juanito", 23));
            listaPersonas.Add(new CLSPersona(2, "María", 12));
            listaPersonas.Add(new CLSPersona(3, "Fernando", 11));
            listaPersonas.Add(new CLSPersona(4, "Amanda", 46));

            return listaPersonas;
        }

    }
}
