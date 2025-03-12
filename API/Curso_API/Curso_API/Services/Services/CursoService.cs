using Curso_API.Domain.Entities;
using Curso_API.Infra.Interface;
using Curso_API.Services.Interface;
using FluentValidation;

namespace Curso_API.Services.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _repository;

    public CursoService(ICursoRepository repository)
    {
        _repository = repository;
    }

    #region CRUD
    public async Task<bool> AdicionarCursoAsync<TValidator>(Curso curso) where TValidator : AbstractValidator<Curso>
    {
        try
        {
            Validacao<TValidator>(curso);
            var resposta = await _repository.AdicionarCurso(curso);
            if (!resposta)
            {
                throw new Exception("Erro inesperado!");
            }
            return resposta;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> AtualizarCursoAsync<TValidator>(Curso curso) where TValidator : AbstractValidator<Curso>
    {
        try
        {
            Validacao<TValidator>(curso);
            var resposta = await _repository.AtualizarCurso(curso);
            if (!resposta)
            {
                throw new Exception($"Não foi possível localizar nenhum curso com id {curso.CursoID}.");
            }
            else
            {
                return resposta;
            }

        }
        catch (Exception e) { throw e; }
    }

    public async Task<Curso> BuscarCursoPorIdAsync(int cursoID)
    {
        try
        {
            var curso = await _repository.BuscarCursoPorId(cursoID);
            if (curso == null)
            {
                throw new Exception($"Não foi possível localizar nenhum aluno com id {cursoID}.");
            }
            return curso;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<List<Curso>> BuscarTodosCursosAsync()
    {
        try
        {
            var cursos = await _repository.BuscarTodosCursos();
            return cursos;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> ExcluirCursoAsync(int cursoID)
    {
        try
        {
            var resposta = await _repository.ExcluirCurso(cursoID);
            if (!resposta)
            {
                throw new Exception($"Não foi possível localizar nenhum curso com id {cursoID}.");
            }
            return resposta;
        }
        catch (Exception e) { throw e; }
    }

    #endregion

    #region Validacao de Entrada
    private static void Validacao<TValidator>(Curso entity) where TValidator : AbstractValidator<Curso>
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
