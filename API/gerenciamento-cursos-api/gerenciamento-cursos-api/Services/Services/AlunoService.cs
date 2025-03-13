using System.Data;
using AutoMapper;
using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Infra.Interfaces;
using gerenciamento_cursos_api.Services.Interface;

namespace gerenciamento_cursos_api.Services.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;
    private readonly IMapper _mapper;

    public AlunoService(IAlunoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TOutputModel> AtualizarAlunoAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Aluno>
    {
        try
        {
            var entity = _mapper.Map<Aluno>(inputModel);

            Validacao<TValidator>(entity);

            bool resposta = await _repository.AtualizarAluno(entity);

            if (!resposta)
                throw new Exception("Não foi possível atualizar o aluno");
            else
            {
                var outputModel = _mapper.Map<TOutputModel>(entity);
                return outputModel;
            }
        }
        catch (Exception ex) { throw; }
    }

    public async Task<TOutputModel> InserirAlunoAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Aluno>
    {
        try
        {
            var entity = _mapper.Map<Aluno>(inputModel);

            Validacao<TValidator>(entity);

            bool resposta = await _repository.InserirAluno(entity);

            if (!resposta)
                throw new Exception("Não foi possível inserir o aluno");
            else
            {
                var outputModel = _mapper.Map<TOutputModel>(entity);
                return outputModel;
            }
        }
        catch (Exception ex) { throw; }
    }

    public Task<List<Aluno>> ListaAlunosAsync()
    {
        try
        {
            var alunos = _repository.BuscarTodosAlunos();

            if (alunos == null)
                throw new Exception("Não há alunos matriculados");
            else
                return alunos;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> RemoverAlunoAsync(int id)
    {
        try
        {
            var alunoRemovido = await _repository.ExcluirAluno(id);

            if (!alunoRemovido)
                throw new Exception("Não foi possível remover o aluno!");
            else
                return true;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Aluno> RetornarAlunoAsync(int id)
    {
        try
        {
            var aluno = await _repository.BuscarAlunoId(id);

            if (aluno == null)
                throw new Exception("O aluno não está matriculado!");
            else
                return aluno;
        }
        catch(Exception ex) { throw; }
    }

    public Task<RetornoPaginado<Aluno>> RetornoPaginadoAlunosAsync(int pagina, int quantidade)
    {
        try
        {
            return _repository.BuscarAlunosPagina(pagina, quantidade);
        }
        catch (Exception ex) { throw; }
    }

    private static void Validacao<TValidator>(Aluno entity) where TValidator : AbstractValidator<Aluno>
    {
        try
        {
            var validator = Activator.CreateInstance<TValidator>();
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => new string(error.ErrorMessage));
                var errorString = string.Join(Environment.NewLine, errors);

                throw new Exception(errorString);
            }
        }
        catch (Exception) { throw; }
    }
}
