using AutoMapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;
using GerenciamentoCurso.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoCurso.Controllers
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

        [HttpPost("Adicionar_Matricula")]

        public async Task<IActionResult> AdicionarCurso([FromBody] MatriculaDto matriculaDto)
        {
            try
            {

                var matriculas = _mapper.Map<Matricula>(matriculaDto);


                var matriculaCriada = await _service.MatricularAluno(matriculas);
                if (matriculaCriada == null)
                {
                    return NotFound();
                }

                return Ok(matriculaCriada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{pagina}/{quantidade}")]

        public async Task<IActionResult> RetornoPaginadoMatricula(int pagina, int quantidade)
        {
            try
            {
                var matricula = await _service.RetornoPaginadoMatricula(pagina, quantidade);
                return Ok(matricula);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletarMatricula(int id)
        {
            try
            {
                var matricula = await _service.RemoverMatricula(id);
                return Ok(matricula);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}

