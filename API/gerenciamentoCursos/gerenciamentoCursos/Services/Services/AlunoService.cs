using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Infra.Interfaces;
using gerenciamentoCursos.Services.Interfaces;

namespace gerenciamentoCursos.Services.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Aluno>> BuscarTodosAlunos()
    {
        try
        {
            return await _repository.BuscarTodosAlunos();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
