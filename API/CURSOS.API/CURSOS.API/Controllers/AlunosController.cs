using Microsoft.AspNetCore.Mvc;
using CURSOS.API.Application.Interfaces;
using CURSOS.API.DTOs;

namespace FaculdadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunosServices _service;

        public AlunoController(IAlunosServices service)
        {
            _service = service;
        }

        [HttpGet("alunos")]
        public async Task<IActionResult> BuscarAlunosAsync()
        {
            try
            {
                var alunos = await _service.BuscarAlunosAsync();
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar alunos: {ex.Message}");
            }
        }

        [HttpGet("aluno/{id}")]
        public async Task<IActionResult> BuscarAlunoPorIdAsync(int id)
        {
            try
            {
                var aluno = await _service.BuscarAlunosPorIdAsync(id);
                if (aluno == null)
                    return NotFound("Aluno não encontrado.");
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar aluno: {ex.Message}");
            }
        }

        [HttpPost("aluno")]
        public async Task<IActionResult> AdicionarAlunoAsync([FromBody] AlunosDTO alunoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var resultado = await _service.AdicionarAlunoAsync(alunoDTO);
                if (!resultado)
                    return BadRequest("Erro ao adicionar aluno.");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar aluno: {ex.Message}");
            }
        }

        [HttpPut("aluno/{id}")]
        public async Task<IActionResult> AtualizarAlunoAsync(int id, [FromBody] AlunosDTO alunoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var resultado = await _service.AtualizarAlunoAsync(alunoDTO);
                if (!resultado)
                    return BadRequest("Erro ao atualizar aluno.");
                return Ok("Aluno atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar aluno: {ex.Message}");
            }
        }

        [HttpDelete("aluno/{id}")]
        public async Task<IActionResult> DeletarAlunosAsync(int id)
        {
            try
            {
                var resultado = await _service.DeletarAlunosAsync(id);
                if (!resultado)
                    return BadRequest("Erro ao excluir aluno.");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir aluno: {ex.Message}");
            }
        }

        [HttpGet("paginado/{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarAlunosPaginadosAsync(int pagina, int quantidade)
        {
            try
            {
                var alunos = await _service.BuscarAlunosPaginadosAsync(pagina, quantidade);
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar alunos paginados: {ex.Message}");
            }
        }
    }
}