using System.Data;
using Dapper;
using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Infra.Interfaces;

namespace gerenciamentoCursos.Infra.Repositories;

public class AlunoRepository: IAlunoRepository
{
    private readonly IDbConnection _connection;

    public AlunoRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Aluno>> BuscarTodosAlunos()
    {
        try
        {
            string sqlAluno = $"SELECT * FROM Alunos;";
            var alunos = await _connection.QueryAsync<Aluno>(sqlAluno);
            return alunos.ToList();
        }
        catch (Exception e) { throw e; }
    }

}
