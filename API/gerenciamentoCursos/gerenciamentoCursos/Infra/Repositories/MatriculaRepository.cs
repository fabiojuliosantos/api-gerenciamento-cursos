using System.Data;
using Dapper;
using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Infra.Interfaces;

namespace gerenciamentoCursos.Infra.Repositories;

public class MatriculaRepository : IMatriculaRepository
{
    private readonly IDbConnection _connection;

    public MatriculaRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<bool> AdicionarMatricula(Matricula matricula)
    {
        try
        {
            string sql = $"INSERT INTO MATRICULAS VALUES (@ALUNOID, @CURSOID,@DATAMATRICULA)";
            var parametros = new
            {
                ALUNOID = matricula.AlunoID,
                CURSOID = matricula.CursoID,
                DATAMATRICULA = matricula.DataMatricula
            };
            var res = await _connection.ExecuteAsync(sql, parametros);
            return res > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<List<Matricula>> BuscarTodasMatriculas()
    {
        try
        {
            string sql = $"SELECT * FROM MATRICULAS";
            var matriculas = await _connection.QueryAsync<Matricula>(sql);
            return matriculas.ToList();
        }
        catch (Exception e) { throw e; }
    }

    public async Task<Matricula> BuscarMatriculaPorID(int id)
    {
        try
        {
            string sql = $"SELECT * FROM MATRICULAS WHERE MATRICULAID = {id}";
            var matricula = await _connection.QueryFirstOrDefaultAsync<Matricula>(sql);
            return matricula;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> AtualizarMatricula(Matricula matricula)
    {
        try
        {
            string sql = $"UPDATE MATRICULAS SET ALUNOID = @ALUNOID, CURSOID = @CURSOID, DATAMATRICULA = @DATAMATRICULA WHERE MATRICULAID = @MATRICULAID";
            var parametros = new
            {
                ALUNOID = matricula.AlunoID,
                CURSOID = matricula.CursoID,
                DATAMATRICULA = matricula.DataMatricula,
                MATRICULAID = matricula.MatriculaID
            };
            var res = await _connection.ExecuteAsync(sql, parametros);
            return res > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> DeletarMatricula(int id)
    {
        try
        {
            string sql = $"DELETE FROM MATRICULAS WHERE MATRICULAID = {id}";
            var res = await _connection.ExecuteAsync(sql);
            return res > 0 ? true : false;
        }
        catch (Exception e) { throw e; }
    }
}
