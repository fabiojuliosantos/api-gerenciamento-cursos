using AutoMapper;
using Curso_API.Domain.Entities;
using Curso_API.Domain.Validators;
using Curso_API.Dto;
using Curso_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Curso_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CursoController : Controller
{
    private readonly ICursoService _service;
    private readonly IMapper _mapper;

    public CursoController(ICursoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("buscar-cursos")]
    public async Task<IActionResult> BuscarTodosCursos()
    {
        try
        {
            var cursos = await _service.BuscarTodosCursosAsync();
            if (cursos == null || cursos.Count == 0)
            {
                return NotFound("Nenhum curso foi encontrado.");
            }
            else
            {
                return Ok(cursos);
            }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet("buscar-curso-id")]
    public async Task<IActionResult> BuscarCursoPorId([FromQuery] int cursoID)
    {
        try
        {
            var curso = await _service.BuscarCursoPorIdAsync(cursoID);
            if (curso == null)
            {
                return NotFound("Nenhum curso foi encontrado.");
            }
            else
            {
                return Ok(curso);
            }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPost("adicionar-curso")]
    public async Task<IActionResult> AdicionarCurso([FromBody] CursoDto cursoDto)
    {
        try
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            var resposta = await _service.AdicionarCursoAsync<CursoValidator>(curso);
            if (resposta) return Ok("Curso cadastrado com sucesso!");
            else { return BadRequest("Erro inesperado!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPut("atualizar-curso")]
    public async Task<IActionResult> AtualizarCurso([FromQuery] int cursoID, [FromBody] CursoDto cursoDto)
    {
        try
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            curso.CursoID = cursoID;
            var resposta = await _service.AtualizarCursoAsync<CursoValidator>(curso);
            if (resposta) return Ok("Curso atualizado com sucesso!");
            else { return BadRequest("Erro inesperado!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpDelete("excluir-curso")]
    public async Task<IActionResult> ExcluirCurso([FromQuery] int cursoID)
    {
        try
        {
            var resposta = await _service.ExcluirCursoAsync(cursoID);
            if (resposta) return Ok("Curso excluído com sucesso!");
            else { return BadRequest("Erro inesperado!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
}
