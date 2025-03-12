using System.Data;
using Curso_API.Domain.Entities;
using Curso_API.Infra.Interface;
using Dapper;

namespace Curso_API.Infra.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly IDbConnection _connection;

    public CursoRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> AdicionarCurso(Curso curso)
    {
        try
        {
            string sql = @$"INSERT INTO Cursos VALUES (@NOME,@DESCRICAO,@CARGAHORARIA)";
            var parametros = new
            {
                NOME = curso.Nome,
                DESCRICAO = curso.Descricao,
                CARGAHORARIA = curso.CargaHoraria
            };
            var resposta = await _connection.ExecuteAsync(sql, parametros);
            return resposta > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> AtualizarCurso(Curso curso)
    {
        try
        {
            string sql = $"UPDATE Cursos SET Nome = @NOME, Descricao = @DESCRICAO, CargaHoraria = @CARGAHORARIA WHERE CursoID = @CURSOID";
            var parametros = new
            {
                NOME = curso.Nome,
                DESCRICAO = curso.Descricao,
                CARGAHORARIA = curso.CargaHoraria,
                CURSOID = curso.CursoID
            };
            var resposta = await _connection.ExecuteAsync(sql, parametros);
            return resposta > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<Curso> BuscarCursoPorId(int cursoID)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM Cursos WHERE CursoID = {cursoID}";
            var curso = await _connection.QueryFirstOrDefaultAsync<Curso>(sql);
            return curso;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<List<Curso>> BuscarTodosCursos()
    {
        try
        {
            string sql = "SELECT * FROM Cursos";
            var cursos = await _connection.QueryAsync<Curso>(sql);
            return cursos.ToList();
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> ExcluirCurso(int cursoID)
    {
        try
        {
            string sql = $"DELETE FROM Cursos WHERE CursoID = {cursoID}";
            var resposta = await _connection.ExecuteAsync(sql);
            return resposta > 0 ? true : false ;
        }
        catch (Exception e) { throw e; }
    }
}
