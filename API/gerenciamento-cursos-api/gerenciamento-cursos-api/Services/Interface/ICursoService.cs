using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Services.Interface;

public interface ICursoService
{
    Task<TOutputModel> InserirCursoAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Curso>;
    Task<TOutputModel> AtualizarCursoAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Curso>;
    Task<List<Curso>> ListaCursosAsync();
    Task<Curso> RetornarCursoAsync(int id);
    Task<bool> RemoverCursoAsync(int id);
}
