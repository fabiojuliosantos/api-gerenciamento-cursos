using System.Data;
using Api.Domain;
using Api.Infra.Interfaces;
using Dapper;

namespace Api.Infra.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly IDbConnection _conn;

    public CursoRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<List<Curso>> ListaTodosCursos()
    {
        try
        {
            string sql = @"SELECT * FROM CURSOS";
            var cursos = await _conn.QueryAsync<Curso>(sql);
            return cursos.ToList();
        }
        catch (Exception) { throw; }
    }

    public async Task<Curso> ListaCursoPorId(int id)
    {
        try
        {
            string sql = @"SELECT TOP 1 * FROM CURSOS WHERE CURSOID = @ID";

            var parametros = new
            {
                ID = id
            };

            return await _conn.QueryFirstOrDefaultAsync<Curso>(sql, parametros);
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Curso>> ListaCursoPorAlunoId(int alunoId)
    {
        string sql = @"
                SELECT
                    C.CURSOID, C.NOME 
                FROM 
                    MATRICULAS M
                INNER JOIN
                    CURSOS C 
                ON
                    M.CURSOID = C.CURSOID
                WHERE 
                    ALUNOID = @ID";

            var parametros = new
            {
                ID = alunoId
            };

            var listaCursos =  await _conn.QueryAsync<Curso>(sql, parametros);

            return listaCursos.ToList();
    }

    public async Task<bool> CriaCurso(Curso curso)
    {
        try
        {
            string sql = "INSERT INTO CURSOS VALUES (@NOME, @DESCRICAO, @CARGAHORARIA)";
    
            var parametros = new
            {
                NOME = curso.Nome,
                DESCRICAO = curso.Descricao,
                CARGAHORARIA = curso.CargaHoraria
            };
    
            var result = await _conn.ExecuteAsync(sql, parametros);
    
            return result > 0;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> AtualizaCurso(Curso curso)
    {
        try
        {
            string sql = "UPDATE CURSOS SET NOME = @NOME, DESCRICAO = @DESCRICAO, CARGAHORARIA = @CARGAHORARIA WHERE CURSOID = @ID";
            var parametros = new
            {
                NOME = curso.Nome,
                DESCRICAO = curso.Descricao,
                CARGAHORARIA = curso.CargaHoraria,
                ID = curso.CursoId
            };

            var result = await _conn.ExecuteAsync(sql, parametros);

            return result > 0;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> DeletaAluno(int id)
    {
        try
        {
            string sql = $"DELETE FROM CURSOS WHERE CURSOID = {id}";
            var result = await _conn.ExecuteAsync(sql);
            return result > 0;
        }
        catch (Exception) { throw; }
    }

}