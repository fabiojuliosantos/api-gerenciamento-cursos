using AutoMapper;
using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Dto;
using gerenciamentoCursos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamentoCursos.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _service;
    private readonly IMapper _mapper;

    public AlunoController(IAlunoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAluno([FromBody] AlunoDto alunoDto)
    {
        try
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            aluno.DataMatricula = DateTime.Now;
            var res = await _service.AdicionarAluno(aluno);
            if (res) return Ok("Aluno cadastrado com sucesso!");
            else { return BadRequest("Erro inesperado ao cadastrar aluno!"); }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodosAlunos()
    {
        try
        {
            var alunos = await _service.BuscarTodosAlunos();
            if (alunos == null || alunos.Count == 0)
            {
                return NotFound("Nenhum aluno cadastrado");
            }
            return Ok(alunos);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarAlunoPorId(int id)
    {
        try
        {
            var aluno = await _service.BuscarAlunoPorId(id);
            if (aluno == null) return NotFound("aluno não encontrado");
            return Ok(aluno);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarAluno(int id, [FromBody] AlunoDto alunoDto)
    {
        try
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            aluno.AlunoID = id;
            aluno.DataMatricula = DateTime.Now;
            var res = await _service.AtualizarAluno(aluno);
            if (res) return Ok("Aluno atualizado com sucesso!");
            return BadRequest("Erro inesperado ao cadastrar aluno!");
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarAluno(int id)
    {
        try
        {
            var res = await _service.DeletarAluno(id);
            if (!res) return NotFound("Aluno não encontrado");
            return Ok("Aluno excluído com sucesso!");
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
}
