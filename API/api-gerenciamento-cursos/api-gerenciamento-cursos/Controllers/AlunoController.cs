using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;
using api_gerenciamento_cursos.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_gerenciamento_cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly IMapper _mapper;

        public AlunoController(IAlunoService alunoService, IMapper mapper)
        {
            _alunoService = alunoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAlunoAsync([FromBody] AlunoDto alunoDto)
        {
            try
            {
                var aluno = _mapper.Map<Aluno>(alunoDto);

                var alunoAdicionado = await _alunoService.AdicionaAlunoAsync(aluno); 
                if (alunoAdicionado == null)
                {
                    return NotFound();
                }
                return Ok(alunoAdicionado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> RecuperaTodosAlunosAsync()
        {
            var alunos = await _alunoService.RecuperaTodosAlunosAsync();

            var alunosComCurso = alunos.Select(aluno => new AlunoComCurso
            {
                AlunoID = aluno.AlunoID,
                Nome = aluno.Nome,
                Idade = aluno.Idade,
                Email = aluno.Email,
                DataMatricula = aluno.DataMatricula,
                Cursos = aluno.Cursos
            });

            return Ok(alunosComCurso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAlunoAsync(int id, [FromBody] AlunoDto alunoDto)
        {
            try
            {
                var aluno = _mapper.Map<Aluno>(alunoDto);
                aluno.AlunoID = id;
                var resultado = await _alunoService.AtualizarAlunoAsync(aluno);
                
                if (resultado == null)
                {
                    return NotFound();
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> BuscaAlunoPorIdAsync(int id)
        {
            var aluno = await _alunoService.BuscaAlunoPorIdAsync(id);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado");
            }

            return Ok(aluno);
        }

        [HttpGet("{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarAlunosPorPaginaAsync(int pagina, int quantidade)
        {
            var alunos = await _alunoService.BuscarAlunoPorPaginaAsync(pagina, quantidade);
            return Ok(alunos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAlunoAsync(int id)
        {
            var resultado = await _alunoService.DeletarAlunoAsync(id);
            if (resultado)
            {
                return NoContent(); 
            }

            return NotFound("Aluno não encontrado");
        }
    }
}
