using AutoMapper;
using Curso_API.Domain.Entities;
using Curso_API.Domain.Validators;
using Curso_API.Dto;
using Curso_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Curso_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : Controller
{
    private readonly IAlunoService _service;
    private readonly IMapper _mapper;

    public AlunoController(IAlunoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("buscar-alunos")]
    public async Task<IActionResult> BuscarTodosAlunos()
    {
        try
        {
            var alunos = await _service.BuscarTodosAlunosAsync();
            if (alunos == null || alunos.Count == 0)
            {
                return NotFound("Nenhum aluno foi encontrado.");
            }
            else
            {
                return Ok(alunos);
            }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet("buscar-aluno-id")]
    public async Task<IActionResult> BuscarAlunoPorId([FromQuery] int alunoID)
    {
        try
        {
            var aluno = await _service.BuscarAlunoPorIdAsync(alunoID);
            if (aluno == null)
            {
                return NotFound("Nenhum aluno foi encontrado.");
            }
            else
            {
                return Ok(aluno);
            }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet("buscar-aluno-paginado")]
    public async Task<IActionResult> BuscarAlunoPaginado([FromQuery] int pagina, [FromQuery] int quantidade)
    {
        try
        {
            var alunos = await _service.BuscarAlunoPorPaginaAsync(pagina, quantidade);
            if (alunos == null)
            {
                return NotFound("Nenhum aluno foi encontrado.");
            }
            else
            {
                return Ok(alunos);
            }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPost("adicionar-aluno")]
    public async Task<IActionResult> AdicionarAluno([FromBody] AlunoDto alunoDto)
    {
        try
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            aluno.DataMatricula = DateTime.Now;
            var resposta = await _service.AdicionarAlunoAsync<AlunoValidator>(aluno);
            if (resposta) return Ok("Aluno cadastrado com sucesso!");
            else { return BadRequest("Erro inesperado!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPut("atualizar-aluno")]
    public async Task<IActionResult> AtualizarAluno([FromQuery] int alunoID, [FromBody] AlunoDto alunoDto)
    {
        try
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            aluno.AlunoID = alunoID;
            aluno.DataMatricula = DateTime.Now;
            var resposta = await _service.AtualizarAlunoAsync<AlunoValidator>(aluno);
            if (resposta) return Ok("Aluno atualizado com sucesso!");
            else { return BadRequest("Erro inesperado!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpDelete("excluir-aluno")]
    public async Task<IActionResult> ExcluirAluno([FromQuery] int alunoID)
    {
        try
        {
            var resposta = await _service.ExcluirAlunoAsync(alunoID);
            if (resposta) return Ok("Aluno excluído com sucesso!");
            else { return BadRequest("Erro inesperado!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
}
