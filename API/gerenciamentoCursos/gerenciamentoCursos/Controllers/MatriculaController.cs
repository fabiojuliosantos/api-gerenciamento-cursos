using AutoMapper;
using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Dto;
using gerenciamentoCursos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamentoCursos.Controllers;

[ApiController]
[Route("[controller]")]
public class MatriculaController : ControllerBase
{
    private readonly IMatriculaService _service;
    private readonly IMapper _mapper;

    public MatriculaController(IMatriculaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarMatricula(MatriculaDto matriculaDto)
    {
        try
        {
            var matricula = _mapper.Map<Matricula>(matriculaDto);
            matricula.DataMatricula = DateTime.Now;
            var res = await _service.AdicionarMatricula(matricula);
            if (res) return Ok("Matricula cadastradoa com sucesso!");
            return BadRequest("Erro inesperado ao cadastrar matricula!");
        }
        catch (Exception e) { return BadRequest(e.Message); }

    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodosMatriculas()
    {
        try
        {
            var matriculas = await _service.BuscarTodasMatriculas();
            if(matriculas == null || matriculas.Count == 0)
            {
                return NotFound("Nenhuma matricula encontrada");
            }
            return Ok(matriculas);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarMatriculaPorID(int id)
    {
        try
        {
            var matricula = await _service.BuscarMatriculaPorID(id);
            if (matricula == null) return NotFound("nenhuma matricula encontrada");
            return Ok(matricula);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarMatricula(int id, [FromBody] MatriculaDto matriculaDto)
    {
        try
        {
            var matricula = _mapper.Map<Matricula>(matriculaDto);
            matricula.DataMatricula = DateTime.Now;
            matricula.MatriculaID = id;
            var res = await _service.AtualizarMatricula(matricula);
            if(res) return Ok("Matricula atualizada com sucesso!");
            return BadRequest("Erro inesperado ao atualizar matricula!");
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarMatricula(int id)
    {
        try
        {
            var res = await _service.DeletarMatricula(id);
            if (res) return Ok("Matricula excluída com sucesso");
            return NotFound("Matricula não encontrada");
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

}
