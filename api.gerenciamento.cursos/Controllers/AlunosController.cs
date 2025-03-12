using Microsoft.AspNetCore.Mvc;
using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Dto;

namespace api.gerenciamento.cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunosController(IAlunoService service)
        {
            _service = service;
        }

        [HttpGet("{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarAlunosPorPaginaAsync(int pagina, int quantidade)
        {
            try
            {
                var alunos = await _service.BuscarAlunosPorPaginaAsync(pagina, quantidade);

                if (alunos == null || !alunos.Alunos.Any())
                {
                    return NotFound("Nenhum aluno localizado em nossa base de dados!");
                }

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro interno: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAlunoPorId(int id)
        {
            try
            {
                var aluno = await _service.BuscarAlunoPorId(id);

                if (aluno == null)
                {
                    return NotFound($"Não foi encontrado nenhum aluno com o ID {id}.");
                }

                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> BuscarTodosAlunos()
        {
            try
            {
                var alunos = await _service.BuscarTodosAlunos();

                if (alunos == null || !alunos.Any())
                {
                    return NotFound("Nenhum aluno localizado em nossa base de dados!");
                }

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
        

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] AlunoInsercaoDto alunoDto)
        {
            try
            {
                var validator = new AlunoInsercaoDtoValidacao();
                var validationResult = await validator.ValidateAsync(alunoDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                //Mapeia o DTO para a entidade Aluno
                var aluno = new Aluno
                {
                    Nome = alunoDto.Nome,
                    Idade = alunoDto.Idade,
                    Email = alunoDto.Email,
                    DataMatricula = alunoDto.DataMatricula
                };

                var resultado = await _service.InserirAluno(aluno);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
            public async Task<IActionResult> Atualizar(int id, [FromBody] AlunoAtualizacaoDto alunoDto)
        {
            try
            {
                var validator = new AlunoAtualizacaoDtoValidacao();
                var validationResult = await validator.ValidateAsync(alunoDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var alunoExistente = await _service.BuscarAlunoPorId(id);
                if (alunoExistente == null)
                {
                    return NotFound("Aluno não encontrado para atualização.");
                }

                //Atualiza os campos do aluno existente com os valores do DTO
                alunoExistente.Nome = alunoDto.Nome;
                alunoExistente.Idade = alunoDto.Idade;
                alunoExistente.Email = alunoDto.Email;
                alunoExistente.DataMatricula = alunoDto.DataMatricula;

                var resultado = await _service.AtualizarAluno(alunoExistente);

                if (!resultado)
                {
                    return NotFound("Aluno não encontrado para atualização.");
                }

                return Ok("Aluno atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var resultado = await _service.ExcluirAluno(id);

                if (!resultado)
                {
                    return NotFound("Aluno não encontrado para exclusão.");
                }

                return Ok("Aluno excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }
    }
}

