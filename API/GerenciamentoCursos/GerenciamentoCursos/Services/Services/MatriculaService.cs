using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Infra.Interfaces;
using GerenciamentoCursos.Services.Interface;

namespace GerenciamentoCursos.Services.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repository;

        public MatriculaService(IMatriculaRepository repository)
        {
            _repository = repository;
        }

        public async Task<RetornoPaginado<Matricula>> BuscarMatriculasPaginadasAsync(int pagina, int quantidade)
        {
            try
            {
                return await _repository.BuscarMatriculasPaginadasAsync(pagina, quantidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar matrículas paginadas", ex);
            }
        }

        public async Task<bool> CriarMatriculaAsync(Matricula matricula)
        {
            try
            {
                return await _repository.CriarMatriculaAsync(matricula);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar matrícula", ex);
            }
        }

        public async Task<bool> ExcluirMatriculaAsync(int id)
        {
            try
            {
                return await _repository.ExcluirMatriculaAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir matrícula", ex);
            }
        }
    }
}
