using System.Data;
using Curso_API.Domain.Entities;
using Curso_API.Dto;
using Curso_API.Infra.Interface;
using Dapper;

namespace Curso_API.Infra.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly IDbConnection _connection;

    public AlunoRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public AlunoRepository()
    {
    }

    public async Task<bool> AdicionarAluno(Aluno aluno)
    {
        try
        {
            string sql = $"INSERT INTO Alunos VALUES (@NOME,@IDADE,@EMAIL,@DATA)";
            var parametros = new
            {
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email,
                DATA = aluno.DataMatricula
            };
            var resposta = await _connection.ExecuteAsync(sql, parametros);
            return resposta > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> AtualizarAluno(Aluno aluno)
    {
        try
        {
            string sql = $"UPDATE Alunos SET Nome = @NOME, Idade = @IDADE, Email = @EMAIL WHERE AlunoID = @ALUNOID";
            var parametros = new
            {
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email,
                ALUNOID = aluno.AlunoID
            };
            var resposta = await _connection.ExecuteAsync(sql, parametros);
            return resposta > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<Aluno> BuscarAlunoPorId(int alunoID)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM Alunos WHERE AlunoID = {alunoID}";
            var aluno = await _connection.QueryFirstOrDefaultAsync<Aluno>(sql);
            string cursoSql = $"SELECT DISTINCT C.CursoID,C.Nome FROM Cursos C INNER JOIN Matriculas M ON C.CursoID = M.CursoID WHERE M.AlunoID = {alunoID}";
            var cursos = await _connection.QueryAsync<ReadCursoDto>(cursoSql);
            if (aluno.Cursos == null) { aluno.Cursos = cursos.ToList(); }
            return aluno;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<RetornoPaginado<Aluno>> BuscarAlunoPorPagina(int pagina, int quantidade)
    {
        try
        {
            string sql = $"SELECT * FROM Alunos ORDER BY AlunoID OFFSET @OFFSET ROWS FETCH NEXT @FETCHNEXT ROWS ONLY";
            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                FETCHNEXT = quantidade
            };
            var alunos = await _connection.QueryAsync<Aluno>(sql, parametros);
            foreach (var aluno in alunos)
            {
                string cursoSql = $"SELECT DISTINCT C.CursoID,C.Nome FROM Cursos C INNER JOIN Matriculas M ON C.CursoID = M.CursoID WHERE M.AlunoID = {aluno.AlunoID}";
                var cursos = await _connection.QueryAsync<ReadCursoDto>(cursoSql);
                if (aluno.Cursos == null) { aluno.Cursos = cursos.ToList(); }

            }
            string sqlQuantidadeAluno = "SELECT COUNT(*) FROM Alunos";
            var quantidadeAlunos = await _connection.QueryFirstOrDefaultAsync<int>(sqlQuantidadeAluno);
            return new RetornoPaginado<Aluno>
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = quantidadeAlunos,
                Lista = alunos.ToList()
            };
        }
        catch (Exception e) { throw e; }
    }

    public async Task<List<Aluno>> BuscarTodosAlunos()
    {
        try
        {
            string sql = $"SELECT * FROM Alunos;";
            var alunos = await _connection.QueryAsync<Aluno>(sql);
            foreach (var aluno in alunos)
            {
                string cursoSql = $"SELECT DISTINCT C.CursoID,C.Nome FROM Cursos C INNER JOIN Matriculas M ON C.CursoID = M.CursoID WHERE M.AlunoID = {aluno.AlunoID}";
                var cursos = await _connection.QueryAsync<ReadCursoDto>(cursoSql);
                if (aluno.Cursos == null) { aluno.Cursos = cursos.ToList(); }
            }
            return alunos.ToList();
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> ExcluirAluno(int alunoID)
    {
        try
        {
            string sql = $"DELETE FROM Alunos WHERE AlunoID = {alunoID}";
            var resposta = await _connection.ExecuteAsync(sql);
            return resposta > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }
}
