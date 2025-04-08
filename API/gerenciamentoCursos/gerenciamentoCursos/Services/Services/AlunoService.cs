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

    public async Task<bool> AdicionarAluno(Aluno  aluno)
    {
        try
        {
            return await _repository.AdicionarAluno(aluno);
        }
        catch (Exception)
        {
            throw;
        }
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

    public async Task<Aluno> BuscarAlunoPorId(int id)
    {
        try
        {
            return await _repository.BuscarAlunoPorId(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AtualizarAluno(Aluno aluno)
    {
        try
        {
            return await _repository.AtualizarAluno(aluno);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeletarAluno(int id)
    {
        try
        {
            return await _repository.DeletarAluno(id);
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<RetornoPaginado<Aluno>> RetornoAlunoPaginado(int pagina, int quantidade)
    {
        try
        {
            return await _repository.RetornoAlunoPaginado(pagina, quantidade);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
