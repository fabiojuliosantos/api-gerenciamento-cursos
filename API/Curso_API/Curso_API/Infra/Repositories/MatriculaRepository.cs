using System.Data;
using Curso_API.Domain.Entities;
using Curso_API.Infra.Interface;
using Dapper;

namespace Curso_API.Infra.Repositories;

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
            string sql = "INSERT INTO Matriculas (@ALUNOID,@CURSOID,@DATAMATRICULA)";
            var parametros = new
            {
                ALUNOID = matricula.AlunoID,
                CURSOID = matricula.CursoID,
                DATAMATRICULA = matricula.DataMatricula
            };
            var resposta = await _connection.ExecuteAsync(sql, parametros);
            return resposta > 0;
        }
        catch (Exception e) { throw e; }
    }

    public async Task<RetornoPaginado<Matricula>> BuscarMatriculaPaginada(int pagina, int quantidade)
    {
        try
        {
            string sql = "SELECT * FROM Matriculas ORDER BY MatriculaID OFFSET @OFFESET ROWS FETCH NEXT @FETCHNEXT ROWS ONLY";
            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                FETCHNEXT = quantidade
            };
            var matriculas = await _connection.QueryAsync<Matricula>(sql, parametros);
            string sqlQuantidadeMatricula = "SELECT COUNT(*) Matriculas";
            var quantidadeMatricula = await _connection.QueryFirstOrDefaultAsync<int>(sqlQuantidadeMatricula);
            return new RetornoPaginado<Matricula>
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = quantidadeMatricula,
                Lista = matriculas.ToList()
            };
        }
        catch (Exception e) { throw e; }
    }

    public async Task<bool> ExcluirMatricula(int matriculaID)
    {
        try
        {
            string sql = $"DELETE FROM Matriculas WHERE MatriculaID = {matriculaID}";
            var resposta = await _connection.ExecuteAsync(sql);
            return resposta > 0;
        }
        catch (Exception e) { throw e; }
    }
}
