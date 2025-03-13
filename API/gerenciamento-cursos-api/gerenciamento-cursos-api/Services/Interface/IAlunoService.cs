using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Services.Interface;

public interface IAlunoService
{
    Task<TOutputModel> InserirAlunoAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Aluno>;
    Task<TOutputModel> AtualizarAlunoAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Aluno>;
    Task<List<Aluno>> ListaAlunosAsync();
    Task<RetornoPaginado<Aluno>> RetornoPaginadoAlunosAsync(int pagina, int quantidade);
    Task<Aluno> RetornarAlunoAsync(int id);
    Task<bool> RemoverAlunoAsync(int id);
}
