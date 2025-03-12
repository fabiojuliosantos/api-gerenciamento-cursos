using System.Data;
using CURSOS.API.Domain;
using CURSOS.API.Infra.Interfaces;
using Dapper;

namespace CURSOS.API.Infra.Repositories;

public class CursosRepository : ICursosRepository
{
    private readonly IDbConnection _cursosRepository;

    public CursosRepository(IDbConnection cursosRepository)
    {
        _cursosRepository = cursosRepository;
    }

    public async Task<bool> AdicionarCursoAsync(Cursos cursos)
    {
        try
        {
            string sql = "INSERT INTO CURSOS (NOME, DESCRICAO, CARGAHORARIA)" +
                "VALUES (@NOME, @DESCRICAO, @CARGAHORARIA)";

            var parametros = new 
            {
                Nome = cursos.Nome,
                Descricao = cursos.Descricao,
                CargaHoraria = cursos.CargaHoraria
            };

            var resultado = await _cursosRepository.ExecuteAsync(sql, parametros);
            return resultado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AtualizarCursoAsync(Cursos cursos)
    {
        try
        {
            string sql = "UPDATE CURSOS SET NOME = @NOME, DESCRICAO = @DESCRICAO, CARGAHORARIA = @CARGAHORARIA WHERE CURSOID = @CURSOID";

            var parametros = new
            {
                Nome = cursos.Nome,
                Descricao = cursos.Descricao,
                CargaHoraria = cursos.CargaHoraria,
                CursoId = cursos.CursoId
            };

            var resultado = await _cursosRepository.ExecuteAsync(sql, parametros);
            return resultado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Cursos> BuscarCursoPorIdAsync(int id)
    {
        try
        {
            string sql = "SELECT * FROM CURSOS WHERE CURSOID = @ID";
            var parametros = new { Id = id };
            return await _cursosRepository.QueryFirstAsync<Cursos>(sql, parametros);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Cursos>> BuscarTodosCursosAsync()
    {
        try
        {
            string sql = "SELECT * FROM CURSOS";
            return await _cursosRepository.QueryAsync<Cursos>(sql);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeletarCursoAsync(int id)
    {
        try
        {
            string sql = "DELETE FROM CURSOS WHERE CURSOID = @ID";
            var parametros = new { ID = id };
            var resultado = await _cursosRepository.ExecuteAsync(sql, parametros);
            return resultado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
