using System.Threading.Tasks;
using Api.Infra.Dto;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _service;

    public AlunosController(IAlunoService service)
    {
        _service = service;
    }

    //O retorno de todos os alunos não traz os cursos correspondentes ao aluno
    [HttpGet("lista-alunos")]
    public async Task<IActionResult> ListaTodosAlunos()
    {
        try
        {
            var alunos = await _service.ListaTodosAlunos();
            return Ok(alunos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListaAlunoPorId(int id)
    {
        try
        {
            var resposta = await _service.BuscaAlunoPorId(id);
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> RegistraAluno(CreateAlunoDto alunoDto)
    {
        try
        {
            var resposta = await _service.CriaAluno(alunoDto);
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> AtualizaAluno(UpdateAlunoDto alunoDto)
    {
        try
        {
            var resposta = await _service.AtualizaAluno(alunoDto);
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaAluno(int id)
    {
        try
        {
            var resposta = await _service.DeletaAluno(id);
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    //A busca paginada não traz a descrição do curso, nem carga horária
    [HttpGet("{pagina}/{quantidade}")]
    public async Task<IActionResult> ListaAlunosPaginada(int pagina, int quantidade)
    {
        try
        {
            var lista = await _service.ListaAlunosPaginado(pagina, quantidade);
            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}