using CURSOS.API.Application.Interfaces;
using CURSOS.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CURSOS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CursosController : ControllerBase
{
    private readonly ICursosServices _service;

    public CursosController(ICursosServices service)
    {
        _service = service;
    }

    [HttpGet("cursos")]
    public async Task<IActionResult>  BuscarCursosAsync()
    {
        try
        {
            var cursos = await _service.BuscarCursoAsync();
            return Ok(cursos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar cursos: {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> BuscarCursosPorIdAsync(int id)
    {
        try
        {
            var cursos = await _service.BuscarCursoPorIdAsync(id);
            if (cursos == null)
            {
                return NotFound("Curso nao encontrado");
            }
            return Ok(cursos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar cursos por {id}: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> InserirCursoAsync([FromBody] CursosDTO cursosDTO)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = await _service.AdicionarCursoAsync(cursosDTO);
            if (!resultado)
            {
                return BadRequest("Erro ao inserir curso");
            }
            return Ok("Curso inserido com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao adicionar cursos: {ex.Message}");
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCursoAsync(int id)
    {
        try
        {
            var resultado = await _service.DeletarCursoAsync(id);
            if(!resultado)
            {
                return BadRequest("erro ao deletar curso");
            }
            return Ok("Curso deletado com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao deletar curso: {ex.Message}");
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarCursoAsync(int id, [FromBody] CursosDTO cursosDTO)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            cursosDTO.CursoId = id;
            var resultado = await _service.AtualizarCursoAsync(cursosDTO);
            if(!resultado)
            {
                return BadRequest("Erro ao atualizar curso");
            }
            return Ok("Atualizacao de curso com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao atualizar o curso: {ex.Message}");
        }
    }
}
