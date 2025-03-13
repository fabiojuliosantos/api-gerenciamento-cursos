using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Services.Interface;

public interface IMatriculaService
{
    Task<TOutputModel> InserirMatriculaAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Matricula>;
    Task<RetornoPaginado<Matricula>> RetornoPaginadoMatriculasAsync(int pagina, int quantidade);
    Task<bool> RemoverMatriculaAsync(int id);
}
