using System.Data;
using Api.Domain;
using Api.Infra.Interfaces;
using Dapper;

namespace Api.Infra.Repositories;

public class MatriculaRepository : IMatriculaRepository
{
    private readonly IDbConnection _conn;

    public MatriculaRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<bool> CriaMatricula(Matricula matricula)
    {
        try
        {
            string sql = @"INSERT INTO MATRICULAS VALUES (@ALUNOID, @CURSOID, @DATAMATRICULA)";
            var parametros = new
            {
                ALUNOID = matricula.AlunoID,
                CURSOID = matricula.CursoID,
                DATAMATRICULA = matricula.DataMatricula
            };

            var result = await _conn.ExecuteAsync(sql, parametros);

            return result > 0;
        }
        catch (Exception) { throw; }
        
    }

    public async Task<bool> DeletaMatricula(int id)
    {
        try
        {
            string sql = $"DELETE FROM MATRICULAS WHERE MATRICULAID = {id}";
            var resultado = await _conn.ExecuteAsync(sql);
            return resultado > 0;
        }
        catch (Exception) { throw; }
    }

    public async Task<RetornoPaginado<Matricula>> ListaMatriculaPaginada(int pagina, int quantidade)
    {
        try
        {
            string sql = "SELECT * FROM MATRICULAS ORDER BY MATRICULAID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";
    
            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                QUANTIDADE = quantidade,
            };
    
            var matriculas = await _conn.QueryAsync<Matricula>(sql, parametros);

            var consultaTotalMatriculas = "SELECT COUNT(*) FROM MATRICULAS";
    
            var totalMatriculas = await _conn.ExecuteScalarAsync<int>(consultaTotalMatriculas);
    
            return new RetornoPaginado<Matricula>()
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = totalMatriculas,
                ListaDados = [.. matriculas],
            };
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Matricula>> ListaMatriculas()
    {
        try
        {
            string sql = "SELECT * FROM MATRICULAS";
            var matriculas = await _conn.QueryAsync<Matricula>(sql);
            return matriculas.ToList();
        }
        catch (Exception) { throw; }
    }
}