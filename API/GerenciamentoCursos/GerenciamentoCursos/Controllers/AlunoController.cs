using AutoMapper;
using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Dto;
using GerenciamentoCursos.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        private readonly IMapper _mapper;

        public AlunoController(IAlunoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("api/alunos")]
        public async Task<IActionResult> CriarAluno([FromBody] AlunoDto alunoDto)
        {
            if (alunoDto == null)
                return BadRequest("Dados inválidos.");

            var aluno = _mapper.Map<Aluno>(alunoDto);

            if (aluno.DataMatricula == DateTime.MinValue)
            {
                aluno.DataMatricula = DateTime.UtcNow;
            }

            var resultado = await _service.CriarAlunoAsync(aluno);
            if (resultado)
                return CreatedAtAction(nameof(CriarAluno), new { id = aluno.AlunoID }, aluno);

            return BadRequest("Erro ao criar aluno.");
        }

        [HttpGet("/api/alunos")]
        public async Task<IActionResult> BuscarTodosAlunos()
        {
            var alunos = await _service.BuscarTodosAlunosAsync();
            return Ok(alunos);
        }


        [HttpGet("/api/alunos/{id}")]
        public async Task<IActionResult> BuscarAlunoPorId(int id)
        {
            var aluno = await _service.BuscarAlunoPorIdAsync(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno);
        }


        [HttpGet("/api/alunos/{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarAlunosPaginados(int pagina = 1, int quantidade = 10)
        {
            if (pagina < 1 || quantidade < 1)
                return BadRequest("Os parâmetros de paginação devem ser maiores que zero.");

            var resultado = await _service.BuscarAlunosPaginadosAsync(pagina, quantidade);
            return Ok(resultado);
        }


        [HttpPut("/api/alunos/{id}")]
        public async Task<IActionResult> AtualizarAluno(int id, [FromBody] AlunoDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);

            if (aluno == null)
                return BadRequest("Dados inválidos.");

            var atualizado = await _service.AtualizarAlunoAsync(id, aluno);
            if (atualizado)
            {
                return Ok(new { mensagem = "Aluno alterado com sucesso." });
            }

            return NotFound("Aluno não encontrado.");
        }

        [HttpDelete("/api/alunos/{id}")]
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            var excluido = await _service.ExcluirAlunoAsync(id);
            if (excluido)
            {
                return Ok(new { mensagem = "Aluno excluído com sucesso." });
            }

            return NotFound("Aluno não encontrado.");
        }

    }
}
