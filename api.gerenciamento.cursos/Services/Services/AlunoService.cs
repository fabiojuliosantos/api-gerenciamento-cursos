using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Infra.Interfaces;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<RetornoPaginadoAluno<Aluno>> BuscarAlunosPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscarAlunosPorPagina(pagina, quantidade);
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

    public async Task<bool> InserirAluno(Aluno aluno)
    {
        try
        {
            return await _repository.InserirAluno(aluno);
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

    public async Task<bool> ExcluirAluno(int id)
    {
        try
        {
            return await _repository.ExcluirAluno(id);
        }
        catch (Exception)
        {

            throw;
        }
    }
}