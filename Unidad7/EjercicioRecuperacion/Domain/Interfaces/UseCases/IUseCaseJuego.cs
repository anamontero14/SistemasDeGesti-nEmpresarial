using Domain.DTOs;
using System.Collections.Generic;

namespace Domain.Interfaces.UseCases
{
    /// <summary>
    /// Interfaz que define el contrato para el caso de uso del Juego
    /// </summary>
    public interface IUseCaseJuego
    {
        /// <summary>
        /// Comprueba los aciertos del usuario comparando sus selecciones con los datos reales
        /// </summary>
        /// <param name="listaConPersonasYDepartamentos">Lista con las selecciones del usuario</param>
        /// <returns>Número de aciertos</returns>
        int comprobarAciertos(List<PersonaConListaDepartamentos> listaConPersonasYDepartamentos);
    }
}