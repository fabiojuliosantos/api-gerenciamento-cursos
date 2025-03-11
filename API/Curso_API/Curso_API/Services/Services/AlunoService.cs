using Curso_API.Domain;
using Curso_API.Infra.Interface;
using Curso_API.Services.Interface;

namespace Curso_API.Services.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AdicionarAlunoAsync(Aluno aluno)
    {
        try
        {
            var resposta = await _repository.AdicionarAluno(aluno);
            return resposta;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> AtualizarAlunoAsync(Aluno aluno)
    {
        try
        {
            var resposta = await _repository.AtualizarAluno(aluno) ;
            return resposta;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<Aluno> BuscarAlunoPorIdAsync(int alunoID)
    {
        try
        {
            var aluno = await _repository.BuscarAlunoPorId(alunoID);
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
            return resposta;
        }
        catch (Exception e) { throw e; }
    }
}
