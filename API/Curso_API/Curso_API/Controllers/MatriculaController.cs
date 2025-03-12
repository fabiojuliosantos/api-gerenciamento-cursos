using AutoMapper;
using Curso_API.Domain.Entities;
using Curso_API.Domain.Validators;
using Curso_API.Dto;
using Curso_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Curso_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class MatriculaController : Controller
{
    private readonly IMatriculaService _service;
    private readonly IMapper _mapper;

    public MatriculaController(IMatriculaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("buscar-matricula-paginado")]
    public async Task<IActionResult> BuscarMatriculaPaginado([FromQuery] int pagina, [FromQuery] int quantidade)
    {
        try
        {
            var matriculas = await _service.BuscarMatriculaPaginadaAsync(pagina, quantidade);
            if (matriculas == null)
            {
                return NotFound("Nenhuma matricula foi encontrada.");
            }
            else
            {
                return Ok(matriculas);
            }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPost("adicionar-matricula")]
    public async Task<IActionResult> AdicionarMatricula([FromBody] MatriculaDto matriculaDto)
    {
        try
        {
            var matricula = _mapper.Map<Matricula>(matriculaDto);
            var resposta = await _service.AdicionarMatriculaAsync<MatriculaValidator>(matricula);
            if (resposta) return Ok("Matrícula efetuada com sucesso!");
            else { return BadRequest("Erro inesperado!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpDelete("excluir-matricula")]
    public async Task<IActionResult> ExcluirMatricula([FromQuery] int matriculaID)
    {
        try
        {
            var resposta = await _service.ExcluirMatriculaAsync(matriculaID);
            if (resposta) return Ok("Matrícula excluída com sucesso!");
            else { return BadRequest("Erro inesperado!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
}
