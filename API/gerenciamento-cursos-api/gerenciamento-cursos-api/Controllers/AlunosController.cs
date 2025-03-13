using gerenciamento_cursos_api.Data.Dtos;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Domain.Validators;
using gerenciamento_cursos_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_cursos_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _service;

    public AlunosController(IAlunoService service)
    {
        _service = service;
    }

    [HttpGet("alunos")]
    public async Task<IActionResult> ListarTodosAlunos()
    {
        try
        {
            var alunos = await _service.ListaAlunosAsync();
            return Ok(alunos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("alunos/{id}")]
    public async Task<IActionResult> RetornarAlunoId(int id)
    {
        try
        {
            var aluno = await _service.RetornarAlunoAsync(id);
            return Ok(aluno);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("alunos/{pagina}/{quantidade}")]
    public async Task<IActionResult> RetornarAlunosPaginado(int pagina, int quantidade)
    {
        try
        {
            var alunosPaginado = await _service.RetornoPaginadoAlunosAsync(pagina, quantidade);
            return Ok(alunosPaginado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("alunos")]
    public async Task<IActionResult> CriarAluno([FromBody] AlunoDTO dto)
    {
        try
        {
            var alunoCriado = await _service.InserirAlunoAsync<AlunoDTO, Aluno, AlunoValidator>(dto);
            return Ok(alunoCriado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("alunos")]
    public async Task<IActionResult> AtualizarAluno([FromBody] UpdateAlunoDTO dto)
    {
        try
        {
            var alunoAtualizado = await _service.AtualizarAlunoAsync<UpdateAlunoDTO, Aluno, AlunoValidator>(dto);
            return Ok(alunoAtualizado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("alunos/{id}")]
    public async Task<IActionResult> RemoverAluno(int id)
    {
        try
        {   
            var aluno = await _service.RemoverAlunoAsync(id);
            return Ok($"Aluno {id} removido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
