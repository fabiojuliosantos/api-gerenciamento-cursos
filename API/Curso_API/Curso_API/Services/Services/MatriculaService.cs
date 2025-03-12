using Curso_API.Domain.Entities;
using Curso_API.Infra.Interface;
using Curso_API.Services.Interface;
using FluentValidation;

namespace Curso_API.Services.Services;

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _repository;

    public MatriculaService(IMatriculaRepository repository)
    {
        _repository = repository;
    }
    #region CRUD

    public async Task<bool> AdicionarMatriculaAsync<TValidator>(Matricula matricula) where TValidator : AbstractValidator<Matricula>
    {
        try
        {
            Validacao<TValidator>(matricula);
            var resposta = await _repository.AdicionarMatricula(matricula);
            if (!resposta)
            {
                throw new Exception("O campo AlunoID ou CursoID está incorreto!");
            }
            else
            {
                return resposta;
            }
        }
        catch (Exception e) { throw e; }
    }

    public async Task<RetornoPaginado<Matricula>> BuscarMatriculaPaginadaAsync(int pagina, int quantidade)
    {
        try
        {
            var matriculas = await _repository.BuscarMatriculaPaginada(pagina, quantidade);
            return matriculas;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> ExcluirMatriculaAsync(int matriculaID)
    {
        try
        {
            var resposta = await _repository.ExcluirMatricula(matriculaID);
            if (!resposta)
            {
                throw new Exception($"Não foi possível localizar nenhum matrícula com id {matriculaID}.");
            }
            return resposta;
        }
        catch (Exception e) { throw e; }
    }
    #endregion

    #region Validação de Entrada
    private static void Validacao<TValidator>(Matricula entity) where TValidator : AbstractValidator<Matricula>
    {
        try
        {
            var validator = Activator.CreateInstance<TValidator>();
            var resposta = validator.Validate(entity);

            if (!resposta.IsValid)
            {
                var errors = resposta.Errors.Select(error => new string(error.ErrorMessage));
                var errorString = string.Join(Environment.NewLine, errors);

                throw new Exception(errorString);
            }
        }
        catch (Exception) { throw; }
    }
    #endregion
}
