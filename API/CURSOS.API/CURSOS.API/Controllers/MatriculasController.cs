using CURSOS.API.Application.Interfaces;
using CURSOS.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CURSOS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatriculasController : ControllerBase
{
    private readonly IMatriculaServices _service;

    public MatriculasController(IMatriculaServices service)
    {
        _service = service;
    }

    [HttpGet("paginado/{pagina}/{quantidade}")]
    public async Task<IActionResult> BuscarTodasMatriculasPaginadasAsync(int pagina, int quantidade)
    {
        try
        {
            var matriculas = await _service.BuscarTodasMatriculasAsync(pagina, quantidade);
            return Ok(matriculas);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar matriculas: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> AdicionarMatriculaPorAlunoAsync([FromBody] MatriculasDTO matriculasDTO)
    {
        try
        {
            var resultado = await _service.AdicionarMatriculaPorAlunoAsync(matriculasDTO);
            if (resultado)
            {
                return Ok("Matricula realizada com sucesso");
            }
            else return BadRequest("Erro ao realizar matricula");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao adicionar matricula por aluno: {ex.Message}");
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelarMatriculaAsync(int id)
    {
        try
        {
            var resultado = await _service.CancelarMatriculaAsync(id);
            if(!resultado)
            {
                return BadRequest("Erro ao cancelar matricula");
            }
            return Ok("Matricula cancelada com sucesso");
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Erro ao cancelar matricula: {ex.Message}");
        }
    }

}
