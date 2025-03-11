using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpPost("api/alunos")]
        public async Task<IActionResult> CriarAluno([FromBody] Aluno aluno)
        {
            if (aluno == null)
                return BadRequest("Dados inválidos.");

            var resultado = await _service.CriarAlunoAsync(aluno);
            if (resultado)
                return CreatedAtAction(nameof(BuscarAlunoPorId), new { id = aluno.AlunoID }, aluno);

            return BadRequest("Erro ao criar aluno.");
        }

        [HttpGet("/api/alunos/{id}")]
        public async Task<IActionResult> BuscarAlunoPorId(int id)
        {
            var aluno = await _service.BuscarAlunoPorIdAsync(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpGet("/api/alunos")]
        public async Task<IActionResult> BuscarTodosAlunos()
        {
            var alunos = await _service.BuscarTodosAlunosAsync();
            return Ok(alunos);
        }

        [HttpGet("/api/alunos/{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarAlunosPaginados([FromQuery] int pagina = 1, [FromQuery] int quantidade = 10)
        {
            if (pagina < 1 || quantidade < 1)
                return BadRequest("Os parâmetros de paginação devem ser maiores que zero.");

            var resultado = await _service.BuscarAlunosPaginadosAsync(pagina, quantidade);
            return Ok(resultado);
        }

        [HttpPut("/api/alunos/{id}")]
        public async Task<IActionResult> AtualizarAluno(int id, [FromBody] Aluno aluno)
        {
            if (aluno == null)
                return BadRequest("Dados inválidos.");

            var atualizado = await _service.AtualizarAlunoAsync(id, aluno);
            if (atualizado)
                return NoContent();

            return NotFound("Aluno não encontrado.");
        }

        [HttpDelete("/api/alunos/{id}")]
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            var excluido = await _service.ExcluirAlunoAsync(id);
            if (excluido)
                return NoContent();

            return NotFound("Aluno não encontrado.");
        }
    }
}
