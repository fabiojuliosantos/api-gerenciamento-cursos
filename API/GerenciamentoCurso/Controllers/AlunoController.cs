using AutoMapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;
using GerenciamentoCurso.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoCurso.Controllers;

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

    [HttpPost("Adicionar-Aluno")]


    public async Task<IActionResult> AdicionarAluno([FromBody] AlunoDto alunoDto)
    {
        try
        {

            var aluno = _mapper.Map<Alunos>(alunoDto);


            var alunoCriado = await _service.AdicionaAlunoAsync(aluno);
            if (alunoCriado == null)
            {
                return NotFound();
            }

            return Ok(alunoCriado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }







    [HttpPut("alunos/{id}")]

    public async Task<IActionResult> AtualizarAluno(int id, [FromBody] AlunoDto alunoDto)
    {
        try
        {
            var aluno = _mapper.Map<Alunos>(alunoDto);
            aluno.AlunoId = id;
            var alunoAtualizado = await _service.AtualizarAlunoAsync(aluno);

            if (alunoAtualizado == null)
            {
                return NotFound();
            }
            return Ok(alunoAtualizado);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }
    [HttpGet]
    public async Task<IActionResult> MostrarTodosAlunos()
    {
        try
        {
            var alunos = await _service.RecuperaTodosAlunosAsync();
            return Ok(alunos);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet("{pagina}/{quantidade}")]

    public async Task <IActionResult> RetornoPaginadoAluno(int pagina, int quantidade)
    {
        try
        {
            var alunos = await _service.BuscarAlunoPorPaginaAsync(pagina, quantidade);
                return Ok(alunos);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }


    }
    [HttpGet("{id}")]

    public async Task <IActionResult> RetornarAlunoId(int id)
    {
        try
        {
            var alunos = await _service.BuscaAlunoPorIdAsync(id);
            return Ok(alunos);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeletarAluno(int id)
    {
        try
        {
            var alunos =await _service.DeletarAlunoAsync(id);
            return Ok(alunos);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }
    
}



    


