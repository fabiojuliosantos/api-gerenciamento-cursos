using Curso_API.Domain.Entities;
using Curso_API.Infra.Interface;
using Curso_API.Services.Interface;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Curso_API.Services.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    #region CRUD
    public async Task<bool> AdicionarAlunoAsync<TValidator>(Aluno aluno) where TValidator : AbstractValidator<Aluno>
    {
        try
        {
            Validacao<TValidator>(aluno);
            var resposta = await _repository.AdicionarAluno(aluno);
            if (!resposta)
            {
                throw new Exception("Erro inesperado!");
            }
            else
            {
                return resposta;
            }
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> AtualizarAlunoAsync<TValidator>(Aluno aluno) where TValidator : AbstractValidator<Aluno>
    {
        try
        {
            Validacao<TValidator>(aluno);
            var alunoAntigo = await BuscarAlunoPorIdAsync(aluno.AlunoID);
            aluno.DataMatricula = alunoAntigo.DataMatricula;
            var resposta = await _repository.AtualizarAluno(aluno);
            if (!resposta)
            {
                throw new Exception($"Não foi possível localizar nenhum aluno com id {aluno.AlunoID}.");
            }
            else
            {
                return resposta;
            }

        }
        catch (Exception e) { throw e; }
    }

    public async Task<Aluno> BuscarAlunoPorIdAsync(int alunoID)
    {
        try
        {
            var aluno = await _repository.BuscarAlunoPorId(alunoID);
            if (aluno == null)
            {
                throw new Exception($"Não foi possível localizar nenhum aluno com id {alunoID}.");
            }
            return aluno;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<RetornoPaginado<Aluno>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            var alunos = await _repository.BuscarAlunoPorPagina(pagina, quantidade);
            return alunos;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<List<Aluno>> BuscarTodosAlunosAsync()
    {
        try
        {
            var alunos = await _repository.BuscarTodosAlunos();
            return alunos;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> ExcluirAlunoAsync(int alunoID)
    {
        try
        {
            var resposta = await _repository.ExcluirAluno(alunoID);
            if (!resposta)
            {
                throw new Exception($"Não foi possível localizar nenhum aluno com id {alunoID}.");
            }
            return resposta;
        }
        catch (Exception e) { throw e; }
    }
    #endregion

    #region Validação de Entrada
    private static void Validacao<TValidator>(Aluno entity) where TValidator : AbstractValidator<Aluno>
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
