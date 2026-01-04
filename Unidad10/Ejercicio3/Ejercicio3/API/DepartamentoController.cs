using Domain.Entities;
using Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace UI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepositoryUseCase _casoDeUsoDepartamento;

        public DepartamentoController(IDepartamentoRepositoryUseCase casoDeUsoD)
        {
            _casoDeUsoDepartamento = casoDeUsoD;
        }

        // GET: api/<DepartamentoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<Departamento> listadoCompleto = new List<Departamento>();

            try
            {
                listadoCompleto = _casoDeUsoDepartamento.getListaDepartamento();

                if (listadoCompleto.Count == 0)
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

        // GET api/<DepartamentoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            Departamento departamento;

            try
            {
                departamento = _casoDeUsoDepartamento.getDepartamentoPorId(id);

                if (departamento == null)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(departamento);
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        public IActionResult Post(Departamento departamento)
        {
            IActionResult salida;
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _casoDeUsoDepartamento.crearDepartamento(departamento);

                if (filasAfectadas == 0)
                {
                    salida = BadRequest();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Departamento departamento)
        {
            IActionResult salida;
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _casoDeUsoDepartamento.actualizarDepartamento(id, departamento);

                if (filasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _casoDeUsoDepartamento.eliminarDepartamento(id);

                if (filasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }
    }
}
