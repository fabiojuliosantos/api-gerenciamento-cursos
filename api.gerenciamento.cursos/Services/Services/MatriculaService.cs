using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Infra.Interfaces;
using api.gerenciamento.cursos.Services.Interface;

namespace api.gerenciamento.cursos.Services.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repository;

        public MatriculaService(IMatriculaRepository repository)
        {
            _repository = repository;
        }

        public async Task<RetornoPaginadoMatricula<Matricula>> BuscarMatriculaPorPaginaAsync(int pagina, int quantidade)
        {
            try
            {
                return await _repository.BuscarMatriculaPorPaginaAsync(pagina, quantidade);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Matricula> BuscarMatriculaPorId(int id)
        {
            try
            {
                return await _repository.BuscarMatriculaPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Matricula>> BuscarTodasMatriculas()
        {
            try
            {
                return await _repository.BuscarTodasMatriculas();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> InserirMatricula(Matricula matricula)
        {
            try
            {
                return await _repository.InserirMatricula(matricula);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ExcluirMatricula(int id)
        {
            try
            {
                return await _repository.ExcluirMatricula(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}