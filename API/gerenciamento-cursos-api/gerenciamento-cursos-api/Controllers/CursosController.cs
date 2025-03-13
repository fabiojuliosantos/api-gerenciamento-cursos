using gerenciamento_cursos_api.Data.Dtos;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Domain.Validators;
using gerenciamento_cursos_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_cursos_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursosController : ControllerBase
{
    private readonly ICursoService _service;

    public CursosController(ICursoService service)
    {
        _service = service;
    }

    [HttpGet("cursos")]
    public async Task<IActionResult> ListarCursos()
    {
        try
        {
            var cursos = await _service.ListaCursosAsync();
            return Ok(cursos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("cursos/{id}")]
    public async Task<IActionResult> RetornarCursoId(int id)
    {
        try
        {
            var curso = await _service.RetornarCursoAsync(id);
            return Ok(curso);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost("cursos")]
    public async Task<IActionResult> CriarCurso([FromBody] CursoDTO dto)
    {
        try
        {
            var cursoCriado = await _service.InserirCursoAsync<CursoDTO, Curso, CursoValidator>(dto);
            return Ok(cursoCriado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("cursos")]
    public async Task<IActionResult> AtualizarCurso([FromBody] UpdateCursoDTO dto)
    {
        try
        {
            var cursoCriado = await _service.AtualizarCursoAsync<UpdateCursoDTO, Curso, CursoValidator>(dto);
            return Ok(cursoCriado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("cursos/{id}")]
    public async Task<IActionResult> RemoverCurso(int id)
    {
        try
        {
            var matriculaCandelada = await _service.RemoverCursoAsync(id);
            return Ok($"Matrícula {id} cancelada com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
