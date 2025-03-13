using Api.Infra.Dto;
using Api.Infra.Interfaces;
using Api.Service.Interfaces;
using Api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class CursosController : ControllerBase
{
    private readonly ICursoService _service;

    public CursosController(ICursoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ListaTodosCursos()
    {
        try
        {
            var cursos = await _service.ListaCursos();
            return Ok(cursos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListaCursoPorId(int id)
    {
        try
        {
            var curso = await _service.ListaCursoPorId(id);
            return Ok(curso);
        }
        catch (CustomerException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CriaCurso(CreateCursoDto cursoDto)
    {
        try
        {
            var cursos = await _service.CriaCurso(cursoDto);
            return Ok(cursos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> AtualizaCurso(UpdateCursoDto cursoDto)
    {
        try
        {
            var result = await _service.AtualizaCurso(cursoDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaCurso(int id)
    {
        try
        {
            var result = await _service.DeletaCurso(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}