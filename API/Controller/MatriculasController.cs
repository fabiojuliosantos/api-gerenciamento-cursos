using Api.Infra.Dto;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class MatriculasController : ControllerBase
{
    private readonly IMatriculaService _service;

    public MatriculasController(IMatriculaService service)
    {
        _service = service;
    }

    [HttpGet("{pagina}/{quantidade}")]
    public async Task<IActionResult> ListaMatriculasPaginada(int pagina, int quantidade)
    {
        try
        {
            var lista = await _service.ListaMatriculaRetornoPaginado(pagina, quantidade);
            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CriaMatricula(CreateMatricula matriculaDto)
    {
        try
        {
            var resposta = await _service.CriaMatricula(matriculaDto);
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ListaMatriculas()
    {
        try
        {
            var resposta = await _service.ListaMatriculas();
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaMatricula(int id)
    {
        try
        {
            var resposta = await _service.DeletaMatricula(id);
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}