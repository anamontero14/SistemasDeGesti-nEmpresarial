using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepositoryUseCase _casoDeUsoPersona;
        private readonly IDepartamentoRepositoryUseCase _casoDeUsoDepartamento;

        public PersonaController(IPersonaRepositoryUseCase casoDeUsoP,
            IDepartamentoRepositoryUseCase casoDeUsoD)
        {
            _casoDeUsoPersona = casoDeUsoP;
            _casoDeUsoDepartamento = casoDeUsoD;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<Persona> listadoCompleto = new List<Persona>();

            try
            {
                listadoCompleto = _casoDeUsoPersona.getListaPersonas();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;

        }

        // POST api/<PersonaController>
        [HttpPost]
        public IActionResult Post(Persona persona)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = _casoDeUsoPersona.crearPersona(persona);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Persona persona)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = _casoDeUsoPersona.actualizarPersona(id, persona);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {
                numFilasAfectadas = _casoDeUsoPersona.eliminarPersona(id);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;
        }

    }
}
