using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Infra.Interfaces;
using GerenciamentoCursos.Services.Interface;

namespace GerenciamentoCursos.Services.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AtualizarCursoAsync(int id, Curso curso)
        {
            try
            {
                return await _repository.AtualizarCursoAsync(id, curso);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar aluno", ex);
            }
        }

        public async Task<Curso> BuscarCursoPorIdAsync(int id)
        {
            try
            {
                return await _repository.BuscarCursoPorIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar curso por ID", ex);
            }
        }

        public async Task<List<Curso>> BuscarTodosCursosAsync()
        {
            try
            {
                return await _repository.BuscarTodosCursosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os cursos", ex);
            }
        }

        public async Task<bool> CriarCursoAsync(Curso curso)
        {
            try
            {
                return await _repository.CriarCursoAsync(curso);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar curso", ex);
            }
        }

        public async Task<bool> ExcluirCursoAsync(int id)
        {
            try
            {
                return await _repository.ExcluirCursoAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir curso", ex);
            }
        }
    }
}
