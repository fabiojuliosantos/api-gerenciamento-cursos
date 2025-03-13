using gerenciamento_cursos_api.Data.Dtos;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Domain.Validators;
using gerenciamento_cursos_api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_cursos_api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MatriculasController : ControllerBase
{
    private readonly IMatriculaService _service;

    public MatriculasController(IMatriculaService service)
    {
        _service = service;
    }

    [HttpGet("matriculas")]
    public async Task<IActionResult> ListarMatriculasPaginada(int pagina, int quantidade)
    {
        try
        {
            var matriculas = await _service.RetornoPaginadoMatriculasAsync(pagina, quantidade);
            return Ok(matriculas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("matriculas")]
    public async Task<IActionResult> MatricularAluno([FromBody] MatriculaDTO dto)
    {
        try
        {
            var matriculaCadastrada = await _service.InserirMatriculaAsync<MatriculaDTO, Matricula, MatriculaValidator>(dto);
            return Ok(matriculaCadastrada);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("matriculas/{id}")]
    public async Task<IActionResult> CancelarMatricula(int id)
    {
        try
        {
            var matriculaCandelada = await _service.RemoverMatriculaAsync(id);
            return Ok($"Matrícula {id} cancelada com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
