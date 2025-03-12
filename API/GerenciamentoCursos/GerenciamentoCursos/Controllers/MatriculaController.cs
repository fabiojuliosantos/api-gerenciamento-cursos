using AutoMapper;
using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Dto;
using GerenciamentoCursos.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;
        private readonly IMapper _mapper;

        public MatriculaController(IMatriculaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("/api/matriculas")]
        public async Task<IActionResult> CriarMatricula([FromBody] MatriculaDto matriculaDto)
        {
            if (matriculaDto == null)
                return BadRequest("Dados inválidos.");

            var matricula = _mapper.Map<Matricula>(matriculaDto);

            if (matricula.DataMatricula == DateTime.MinValue)
            {
                matricula.DataMatricula = DateTime.UtcNow;
            }

            var resultado = await _service.CriarMatriculaAsync(matricula);
            if (resultado)
                return CreatedAtAction(nameof(CriarMatricula), new { id = matricula.MatriculaID }, matricula);

            return BadRequest("Erro ao criar matrícula.");
        }

        [HttpGet("/api/matriculas/{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarMatriculasPaginadas(int pagina = 1, int quantidade = 10)
        {
            if (pagina < 1 || quantidade < 1)
                return BadRequest("Os parâmetros de paginação devem ser maiores que zero.");

            var resultado = await _service.BuscarMatriculasPaginadasAsync(pagina, quantidade);
            return Ok(resultado);
        }

        [HttpDelete("/api/matriculas/{id}")]
        public async Task<IActionResult> ExcluirMatricula(int id)
        {
            var excluido = await _service.ExcluirMatriculaAsync(id);
            if (excluido)
            {
                return Ok(new { mensagem = "Matrícula excluída com sucesso." });
            }

            return NotFound("Matrícula não encontrada.");
        }
    }
}
