using System.Data;
using Dapper;
using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Infra.Interfaces;

namespace gerenciamentoCursos.Infra.Repositories;

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
            var sql = $"INSERT INTO CURSOS VALUES (@NOME,@DESCRICAO,@CARGAHORARIA)";
            var parametros = new
            {
                NOME = curso.Nome,
                DESCRICAO = curso.Descricao,
                CARGAHORARIA = curso.CargaHoraria
            };

            var res = await _connection.ExecuteAsync(sql, parametros);
            return res > 0 ? true : false;
        }
        catch(Exception e) { throw e; }
    }

    public async Task<List<Curso>> BuscarTodosCursos()
    {
        try
        {
            string sql = $"SELECT * FROM CURSOS";

            var cursos = await _connection.QueryAsync<Curso>(sql);
            return cursos.ToList();
        }
        catch (Exception e) { throw e; }

    }

    public async Task<Curso> BuscarCursoPorID(int id)
    {
        try
        {
            string sql = $"SELECT * FROM CURSOS WHERE CURSOID = {id}";
            var curso = await _connection.QueryFirstOrDefaultAsync<Curso>(sql);
            return curso;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> AtualizarCurso(Curso curso)
    {
        try
        {
            string sql = $"UPDATE CURSOS SET NOME = @NOME, DESCRICAO = @DESCRICAO, CARGAHORARIA = @CARGAHORARIA WHERE CURSOID = @CURSOID";
            var parametros = new
            {
                NOME = curso.Nome,
                DESCRICAO = curso.Descricao,
                CARGAHORARIA = curso.CargaHoraria,
                CURSOID = curso.CursoID
            };
            var res = await _connection.ExecuteAsync(sql, parametros);
            return res > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> DeletarCurso(int id)
    {
        try
        {
            string sql = $"DELETE FROM CURSOS WHERE CURSOID = {id}";
            var res = await _connection.ExecuteAsync(sql);
            return res > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

}
