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
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;
        private readonly IMapper _mapper;

        public CursoController(ICursoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }




        [HttpPost("Adicionar_Curso")]

        public async Task<IActionResult> AdicionarCurso([FromBody] CursoDto cursoDto)
        {
            try
            {

                var curso = _mapper.Map<Cursos>(cursoDto);


                var cursoCriado = await _service.CriarCurso(curso);
                if (cursoCriado == null)
                {
                    return NotFound();
                }

                return Ok(cursoCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("AtualizarCurso/{id}")]
        public async Task<IActionResult> AtualizarCurso(int id, [FromBody] CursoDto cursoDto)
        {

            try
            {
                var cursos = _mapper.Map<Cursos>(cursoDto);
                cursos.CursoId = id;
                var cursosAtualizados = await _service.AtualizarCurso(cursos);

                if (cursosAtualizados == null)
                {
                    return NotFound();
                }
                return Ok(cursosAtualizados);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("CursosLista")]

        public async Task<IActionResult> MostrarTodosAlunos()
        {
            try
            {
                var cursos = await _service.ExibirCursos();
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]

        public async Task<IActionResult> ExibirAlunosPorId(int id)
        {
            try
            {
                var alunos = await _service.RetornoCursoId(id);
                return Ok(alunos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleterCurso(int id)
        {
            try
            {
                var cursos = await _service.DeletarCurso(id);
                return Ok(cursos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


    }
}

