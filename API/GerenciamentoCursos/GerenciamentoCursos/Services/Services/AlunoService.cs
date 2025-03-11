using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Infra.Interfaces;
using GerenciamentoCursos.Services.Interface;

namespace GerenciamentoCursos.Services.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AtualizarAlunoAsync(int id, Aluno aluno)
    {
        try
        {
            return await _repository.AtualizarAlunoAsync(id, aluno);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar aluno", ex);
        }
    }

    public async Task<Aluno> BuscarAlunoPorIdAsync(int id)
    {
        try
        {
            return await _repository.BuscarAlunoPorIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar aluno por ID", ex);
        }
    }

    public async Task<RetornoPaginado<Aluno>> BuscarAlunosPaginadosAsync(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscarAlunosPaginadosAsync(pagina, quantidade);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar alunos paginados", ex);
        }
    }

    public async Task<List<Aluno>> BuscarTodosAlunosAsync()
    {
        try
        {
            return await _repository.BuscarTodosAlunosAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar todos os alunos", ex);
        }
    }

    public async Task<bool> CriarAlunoAsync(Aluno aluno)
    {
        try
        {
            return await _repository.CriarAlunoAsync(aluno);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao criar aluno", ex);
        }
    }

    public async Task<bool> ExcluirAlunoAsync(int id)
    {
        try
        {
            return await _repository.ExcluirAlunoAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir aluno", ex);
        }
    }
}
