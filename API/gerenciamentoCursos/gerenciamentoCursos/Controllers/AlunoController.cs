using AutoMapper;
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
}
