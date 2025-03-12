using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.gerenciamento.cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculasController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculasController(IMatriculaService service)
        {
            _service = service;
        }
        [HttpGet("{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarMatriculasPorPagina(int pagina, int quantidade)
        {
            try
            {
                var matriculas = await _service.BuscarMatriculaPorPaginaAsync(pagina, quantidade);

                if (matriculas == null || !matriculas.Matriculas.Any())
                {
                    return NotFound("Nenhuma matrícula encontrada.");
                }

                return Ok(matriculas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Houve um erro interno: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarMatriculaPorId(int id)
        {
            try
            {
                var matricula = await _service.BuscarMatriculaPorId(id);

                if (matricula == null)
                {
                    return NotFound($"Nenhuma matrícula encontrada com o ID {id}.");
                }

                return Ok(matricula);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Houve um erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodasMatriculas()
        {
            try
            {
                var matriculas = await _service.BuscarTodasMatriculas();

                if (matriculas == null || !matriculas.Any())
                {
                    return NotFound("Nenhuma matrícula foi encontrada.");
                }

                return Ok(matriculas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Houve um erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InserirMatricula([FromBody] Matricula matricula)
        {
            try
            {
                var resultado = await _service.InserirMatricula(matricula);

                if (!resultado)
                {
                    return BadRequest("Houve um erro ao inserir matrícula.");
                }

                return Ok("Matrícula inserida com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Houve um erro interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirMatricula(int id)
        {
            try
            {
                var resultado = await _service.ExcluirMatricula(id);

                if (!resultado)
                {
                    return NotFound("Não foi possível exclusão, pois a matrícula não encontrada em nossa base de dados.");
                }

                return Ok("Matrícula excluída com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Houve um erro interno: {ex.Message}");
            }
        }
    }
}

