using AutoMapper;
using FluentValidation;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Infra.Interfaces;
using gerenciamento_cursos_api.Services.Interface;

namespace gerenciamento_cursos_api.Services.Services;

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _repository;
    private readonly IMapper _mapper;

    public MatriculaService(IMatriculaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TOutputModel> InserirMatriculaAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Matricula>
    {
        try
        {
            var entity = _mapper.Map<Matricula>(inputModel);

            Validacao<TValidator>(entity);

            bool resposta = await _repository.MatricularAluno(entity);

            if (!resposta)
                throw new Exception("Não foi possível realizar matrícula!");
            else
            {
                var outputModel = _mapper.Map<TOutputModel>(entity);
                return outputModel;
            }
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> RemoverMatriculaAsync(int id)
    {
        try
        {
            var matriculaCancelada = await _repository.CancelarMatricula(id);

            if (!matriculaCancelada)
                throw new Exception("Não foi possível cancelar a matrícula!");
            else
                return true;
        }
        catch (Exception ex) { throw; }
    }

    public Task<RetornoPaginado<Matricula>> RetornoPaginadoMatriculasAsync(int pagina, int quantidade)
    {
        try
        {
            return _repository.BuscarMatriculaPagina(pagina, quantidade);
        }
        catch (Exception ex) { throw; }
    }

    private static void Validacao<TValidator>(Matricula entity) where TValidator : AbstractValidator<Matricula>
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
