using Curso_API.Domain.Entities;
using FluentValidation;

namespace Curso_API.Services.Interface;

public interface IMatriculaService
{
    Task<bool> AdicionarMatriculaAsync<TValidator>(Matricula matricula) where TValidator : AbstractValidator<Matricula>;
    Task<RetornoPaginado<Matricula>> BuscarMatriculaPaginadaAsync(int pagina, int quantidade);
    Task<bool> ExcluirMatriculaAsync(int matriculaID);
}
