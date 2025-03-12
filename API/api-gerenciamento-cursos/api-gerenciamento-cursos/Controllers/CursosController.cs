using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;
using api_gerenciamento_cursos.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_gerenciamento_cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : Controller
    {
        private readonly ICursosService _cursosService;
        private readonly IMapper _mapper;

        public CursosController(ICursosService cursosService, IMapper mapper)
        {
            _cursosService = cursosService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarCursosAsync()
        {
            var cursos = await _cursosService.RecuperaCursosAsync();
            if (cursos == null)
            {
                return NotFound();
            }
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCursosPorIdAsync(int id)
        {
            var cursos = await _cursosService.RecuperaCursosPorIdAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }
            return Ok(cursos);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCursosAsync([FromBody] CursoDto cursosDto)
        {
            try
            {
                var cursos = _mapper.Map<Cursos>(cursosDto);
                var cursosAdicionado = await _cursosService.AdicionaCursosAsync(cursos);
                if (cursosAdicionado == null)
                {
                    return NotFound();
                }
                return Ok(cursosAdicionado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCursosAsync(int id, [FromBody] CursoDto cursosDto)
        {
            try
            {
                var cursos = _mapper.Map<Cursos>(cursosDto);
                cursos.CursoID = id;
                var resultado = await _cursosService.AtualizarCursosAsync(cursos);
                if (resultado == null)
                {
                    return NotFound();
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCursosAsync(int id)
        {
            var resultado = await _cursosService.DeletaCursosAsync(id);
            if (resultado == false)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

    }
}
