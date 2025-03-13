using AutoMapper;
using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Dto;
using GerenciamentoCursos.Services.Interface;
using GerenciamentoCursos.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;
        private readonly IMapper _mapper;

        public CursoController(ICursoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("/api/cursos")]
        public async Task<IActionResult> CriarCurso([FromBody] CursoDto cursoDto)
        {
            if (cursoDto == null)
                return BadRequest("Dados inválidos.");

            var curso = _mapper.Map<Curso>(cursoDto);

            var erros = Validacoes.ValidarCurso(curso);

            if (erros.Any())
            {
                return BadRequest(new { mensagensDeErro = erros });
            }

            var resultado = await _service.CriarCursoAsync(curso);
            if (resultado)
                return CreatedAtAction(nameof(CriarCurso), new { id = curso.CursoID }, curso);

            return BadRequest("Erro ao criar curso.");
        }

        [HttpGet("/api/cursos")]
        public async Task<IActionResult> BuscarTodosCursos()
        {
            var cursos = await _service.BuscarTodosCursosAsync();
            return Ok(cursos);
        }

        [HttpGet("/api/cursos/{id}")]
        public async Task<IActionResult> BuscarCursoPorId(int id)
        {
            var curso = await _service.BuscarCursoPorIdAsync(id);
            if (curso == null)
                return NotFound("Aluno não encontrado.");

            return Ok(curso);
        }

        [HttpPut("/api/cursos/{id}")]
        public async Task<IActionResult> AtualizarCurso(int id, [FromBody] CursoDto cursoDto)
        {
            var curso = _mapper.Map<Curso>(cursoDto);

            if (curso == null)
                return BadRequest("Dados inválidos.");

            var erros = Validacoes.ValidarCurso(curso);

            if (erros.Any())
            {
                return BadRequest(new { mensagensDeErro = erros });
            }

            var atualizado = await _service.AtualizarCursoAsync(id, curso);
            if (atualizado)
            {
                return Ok(new { mensagem = "Curso alterado com sucesso." });
            }

            return NotFound("Curso não encontrado.");
        }

        [HttpDelete("/api/cursos/{id}")]
        public async Task<IActionResult> ExcluirCurso(int id)
        {
            var excluido = await _service.ExcluirCursoAsync(id);
            if (excluido)
            {
                return Ok(new { mensagem = "Curso excluído com sucesso." });
            }

            return NotFound("Aluno não encontrado.");
        }

    }
}
