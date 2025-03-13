using AutoMapper;
using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Infra.Interfaces;
using gerenciamento_cursos_api.Services.Interface;

namespace gerenciamento_cursos_api.Services.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _repository;
    private readonly IMapper _mapper;

    public CursoService(ICursoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TOutputModel> AtualizarCursoAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Curso>
    {
        try
        {
            var entity = _mapper.Map<Curso>(inputModel);

            Validacao<TValidator>(entity);

            bool resposta = await _repository.AtualizarCurso(entity);

            if (!resposta)
                throw new Exception("Não foi possível atualizar o curso");
            else
            {
                var outputModel = _mapper.Map<TOutputModel>(entity);
                return outputModel;
            }
        }
        catch (Exception ex) { throw; }
    }

    public async Task<TOutputModel> InserirCursoAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Curso>
    {
        try
        {
            var entity = _mapper.Map<Curso>(inputModel);

            Validacao<TValidator>(entity);

            bool resposta = await _repository.InserirCurso(entity);

            if (!resposta)
                throw new Exception("Não foi possível atualizar o curso");
            else
            {
                var outputModel = _mapper.Map<TOutputModel>(entity);
                return outputModel;
            }
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Curso>> ListaCursosAsync()
    {
        try
        {
            var cursos = await _repository.BuscarTodosCursos();

            if (cursos == null)
                throw new Exception("Não há cursos matriculados");
            else
                return cursos;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> RemoverCursoAsync(int id)
    {
        try
        {
            var cursoRemovido = await _repository.RemoverCurso(id);

            if (!cursoRemovido)
                throw new Exception("Não foi possível remover o curso!");
            else
                return true;
        }
        catch (Exception) { throw; }
        
    }

    public async Task<Curso> RetornarCursoAsync(int id)
    {
        try
        {
            var aluno = await _repository.BuscarCursoId(id);

            if (aluno == null)
                throw new Exception("O curso não está registrado no sistema!");
            else
                return aluno;
        }
        catch (Exception ex) { throw; }
        
    }

    private static void Validacao<TValidator>(Curso entity) where TValidator : AbstractValidator<Curso>
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
