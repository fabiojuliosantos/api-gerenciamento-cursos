using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Infra.Interfaces;
using api.gerenciamento.cursos.Service.Interface;

namespace api.gerenciamento.cursos.Service.Services 
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }

        public async Task<RetornoPaginadoCurso<Curso>> BuscarCursosPorPaginaAsync(int pagina, int quantidade)
        {
            try
            {
                return await _repository.BuscarCursosPorPaginaAsync(pagina, quantidade);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> AtualizarCurso(Curso curso)
        {
            try
            {
                return await _repository.AtualizarCurso(curso);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Curso> BuscarCursoPorId(int id)
        {
            try
            {
                return await _repository.BuscarCursoPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Curso>> BuscarTodosCursosAsync()
        {
            try
            {
                return await _repository.BuscarTodosCursos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ExcluirCurso(int id)
        {
            try
            {
                return await _repository.ExcluirCurso(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InserirCurso(Curso curso)
        {
            try
            {
                return await _repository.InserirCurso(curso);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
