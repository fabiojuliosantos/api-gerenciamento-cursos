using System.Data;
using CURSOS.API.Domain;
using CURSOS.API.Infra.Interfaces;
using Dapper;

namespace CURSOS.API.Infra.Repositories;

public class MatriculaRepository : IMatriculaRepository
{
    private readonly IDbConnection _MatriculaRepository;

    public MatriculaRepository(IDbConnection matriculaRepository)
    {
        _MatriculaRepository = matriculaRepository;
    }

    public async Task<bool> AdicionarMatriculaPorAlunoAsync(Matricula matricula)
    {
        try
        {
            string sql = "INSERT INTO MATRICULAS (ALUNOID, CURSOID, DATAMATRICULA) VALUES" +
                "(@ALUNOID, @CURSOID, @DATAMATRICULA)";

            var parametros = new
            {
                AlunoId = matricula.AlunoId,
                CursoId = matricula.CursoId,
                DataMatricula = matricula.DataMatricula
            };

            var resultado = await _MatriculaRepository.ExecuteAsync(sql, parametros);
            return resultado > 0;
        }
        catch (Exception)
        {
            throw;
        };
    }

    public async Task<RetornoPaginado<Matricula>> BuscarTodasMatriculasAsync(int pagina, int quantidade)
    {
        try
        {
            string sql = "SELECT * FROM MATRICULAS " +
                "ORDER BY MATRICULAID" +
                "OFFSET @OFFSET ROWS FETCH NEXT @FETCH ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                FETCH = quantidade
            };

            var resultado = await _MatriculaRepository.QueryAsync<Matricula>(sql, parametros);
            var sqlQtdMatricula = "SELECT COUNT(*) FROM MATRICULAS";
            var qtdMatriculas = await _MatriculaRepository.QueryFirstOrDefaultAsync<int>(sqlQtdMatricula);

            return new RetornoPaginado<Matricula> 
            {
                Pagina = pagina,
                QtdaPagina = quantidade,
                TotalRegistros = qtdMatriculas,
                Itens = resultado.ToList()
            };
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<bool> CancelarMatriculaAsync(int id)
    {
        try
        {
            string sql = "DELETE FROM MATRICULAS WHERE MATRICULAID = @ID";
            var parametros = new { Id = id };
            var resultado = await _MatriculaRepository.ExecuteAsync(sql, parametros);
            return resultado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
