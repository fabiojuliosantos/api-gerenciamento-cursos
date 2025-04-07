using AutoMapper;
using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Dto;
using gerenciamentoCursos.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamentoCursos.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _service;
    private readonly IMapper _mapper;

    public CursoController(ICursoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAluno(CursoDto cursoDto)
    {
        try
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            var res = await _service.AdicionarCurso(curso);
            if (res) return Ok("Curso cadastrado com sucesso!");
            return BadRequest("Erro inesperado ao cadastrar curso!");
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodosCursos()
    {
        try
        {
            var cursos = await _service.BuscarTodosCursos();
            if (cursos == null || cursos.Count == 0)
            {
                return NotFound("Nenhum curso cadastrado!");
            }
            return Ok(cursos);

        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarCursoPorID(int id)
    {
        try
        {
            var curso = await _service.BuscarCursoPorID(id);
            if (curso == null) return NotFound("Curso não encontrado!");
            return Ok(curso);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarCurso(int id, [FromBody] CursoDto cursoDto)
    {
        try
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            curso.CursoID = id;
            var res = await _service.AtualizarCurso(curso);
            if (res) return Ok("Curso atualizado com sucesso!");
            return BadRequest("Erro inesperado ao cadastrar curso!");
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCurso(int id)
    {
       try
        {
            var res = await _service.DeletarCurso(id);
            if (!res) return NotFound("Curso não encontrado");
            return Ok("Curso excluído com sucesso!");
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
}
