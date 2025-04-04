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

    public async Task<bool> AdicionarAluno(Aluno aluno)
    {
        try
        {
            string sql = $"INSERT INTO ALUNOS VALUES (@NOME,@IDADE,@EMAIL,@DATA)";
            var parametros = new
            {
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email,
                DATA = aluno.DataMatricula
            };

            var result = await _connection.ExecuteAsync(sql, parametros);
            return result > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
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

    public async Task<Aluno> BuscarAlunoPorId(int id)
    {
        try
        {
            var sql = $"SELECT * FROM ALUNOS WHERE ALUNOID = {id}";
            var aluno = await _connection.QueryFirstOrDefaultAsync<Aluno>(sql);
            return aluno;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> AtualizarAluno(Aluno aluno)
    {
        try
        {
            var sql = $"UPDATE ALUNOS SET NOME = @NOME,IDADE = @IDADE,EMAIL = @EMAIL, DATAMATRICULA = @DATAMATRICULA WHERE ALUNOID = @ALUNOID";
            var parametros = new
            {
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email,
                DATAMATRICULA = aluno.DataMatricula,
                ALUNOID = aluno.AlunoID
            };

            var result = await _connection.ExecuteAsync(sql, parametros);
            return result > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> DeletarAluno(int id)
    {
        try {
            var sql = $"DELETE FROM ALUNOS WHERE ALUNOID = {id}";
            var res = await _connection.ExecuteAsync(sql);
            return res > 0 ? true : false;
        }
        catch (Exception e) { throw e; }

    }
    
}
