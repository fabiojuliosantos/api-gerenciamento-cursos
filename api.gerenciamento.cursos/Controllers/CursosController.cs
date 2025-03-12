using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.gerenciamento.cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _service;

        public CursosController(ICursoService service)
        {
            _service = service;
        }

        [HttpGet("{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarCursosPorPaginaAsync(int pagina, int quantidade)
        {
            try
            {
                var cursos = await _service.BuscarCursosPorPaginaAsync(pagina, quantidade);

                if (cursos == null)
                {
                    return NotFound("Nenhum curso localizado em nossa base de dados!");
                }

                return Ok(cursos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosCursos()
        {
            try
            {
                var cursos = await _service.BuscarTodosCursosAsync();

                if (cursos == null || !cursos.Any())
                {
                    return NotFound("Nenhum curso localizado!");
                }

                return Ok(cursos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var curso = await _service.BuscarCursoPorId(id);

                if (curso == null)
                {
                    return NotFound($"Nenhum curso localizado com o id {id}.");
                }

                return Ok(curso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] Curso curso)
        {
            try
            {
                var resultado = await _service.InserirCurso(curso);
                if (resultado)
                {
                    return Ok("Curso inserido com sucesso!");
                }
                return BadRequest("Houve erro ao inserir curso.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] Curso curso)
        {
            try
            {
                var resultado = await _service.AtualizarCurso(curso);
                if (resultado)
                {
                    return Ok("Curso atualizado com sucesso!");
                }
                return BadRequest("Houve erro ao atualizar curso.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var resultado = await _service.ExcluirCurso(id);
                if (resultado)
                {
                    return Ok("Curso excluído com sucesso!");
                }
                return BadRequest("Hovue erro ao excluir curso.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
