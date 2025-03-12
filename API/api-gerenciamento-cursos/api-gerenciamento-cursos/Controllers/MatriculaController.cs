using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;
using api_gerenciamento_cursos.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_gerenciamento_cursos.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> AdicionarMatriculaAsync([FromBody] MatriculaDto matriculaDto)
        {
            try
            {
                var matricula = _mapper.Map<Matriculas>(matriculaDto);
                var matriculaAdicionada = await _service.AdicionarMatriculaAsync(matricula);
                if (matriculaAdicionada == null)
                {
                    return NotFound();
                }
                return Ok(matriculaAdicionada);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscaTodasAsMatriculasPaginado([FromQuery] int pag, [FromQuery] int qtd)
        {
            var matriculas = await _service.ListarMatriculasPaginadoAsync(pag, qtd);
            if (matriculas == null)
            {
                return NotFound();
            }
            return Ok(matriculas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarMatricula(int id)
        {
            var matricula = await _service.DeletarMatriculaAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            return Ok(matricula);
        }
    }
}
