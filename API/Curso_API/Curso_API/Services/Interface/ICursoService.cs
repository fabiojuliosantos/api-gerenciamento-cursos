using Curso_API.Domain.Entities;
using FluentValidation;

namespace Curso_API.Services.Interface;

public interface ICursoService
{
    Task<List<Curso>> BuscarTodosCursosAsync();
    Task<Curso> BuscarCursoPorIdAsync(int cursoID);
    Task<bool> AdicionarCursoAsync<TValidator>(Curso curso) where TValidator : AbstractValidator<Curso>;
    Task<bool> AtualizarCursoAsync<TValidator>(Curso curso) where TValidator : AbstractValidator<Curso>;
    Task<bool> ExcluirCursoAsync(int cursoID);
}
