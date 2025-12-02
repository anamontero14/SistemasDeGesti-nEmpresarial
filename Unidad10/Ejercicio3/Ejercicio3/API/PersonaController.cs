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

                listadoCompleto = _casoDeUsoPersona.get;
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

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
