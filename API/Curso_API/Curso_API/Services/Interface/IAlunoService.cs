using Curso_API.Domain.Entities;
using FluentValidation;

namespace Curso_API.Services.Interface;

public interface IAlunoService
{
    Task<RetornoPaginado<Aluno>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade);
    Task<List<Aluno>> BuscarTodosAlunosAsync();
    Task<Aluno> BuscarAlunoPorIdAsync(int alunoID);
    Task<bool> AdicionarAlunoAsync<TValidator>(Aluno aluno) where TValidator : AbstractValidator<Aluno>;
    Task<bool> AtualizarAlunoAsync<TValidator>(Aluno aluno) where TValidator : AbstractValidator<Aluno>;
    Task<bool> ExcluirAlunoAsync(int alunoID);
}
