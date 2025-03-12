using System.Data;
using CURSOS.API.Domain;
using CURSOS.API.Infra.Interfaces;
using Dapper;

namespace CURSOS.API.Infra.Repositories;

public class AlunosRepository : IAlunosRepository
{
    private readonly IDbConnection _context;

    public AlunosRepository(IDbConnection context)
    {
        _context = context;
    }

    public async Task<bool> AdicionarAlunoAsync(Alunos alunos)
    {
        try
        {
            string sqlVerificarEmail = "SELECT COUNT(*) FROM ALUNOS WHERE EMAIL = @EMAIL";

            var emailExiste = await _context.ExecuteScalarAsync<int>(sqlVerificarEmail, new { Email = alunos.Email });

            if(emailExiste > 0)
            {
                throw new Exception("Email ja cadastrado");
            }

            string sql = "INSERT INTO ALUNOS (NOME, IDADE, EMAIL, DATAMATRICULA)" +
                "VALUES (@NOME, @IDADE, @EMAIL, @DATAMATRICULA)";

            var parametros = new 
            {
                Nome = alunos.Nome,
                Idade = alunos.Idade,
                Email = alunos.Email,
                DataMatricula = alunos.DataMatricula
            };

            var resultado = await _context.ExecuteAsync(sql, parametros);
            return resultado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AtualizarAlunoAsync(Alunos alunos)
    {
        try
        {
            string sql = "UPDATE ALUNOS SET NOME = @NOME, IDADE = @IDADE, EMAIL = @EMAIL" +
                "DATAMATRICULA = @DATAMATRICULA WHERE ALUNOID = @ALUNOID";

            var parametros = new
            {
                AlunoId = alunos.AlunoId,
                Nome = alunos.Nome,
                Idade = alunos.Idade,
                Email = alunos.Email,
                DataMatricula = alunos.DataMatricula
            };

            var resultado = await _context.ExecuteAsync(sql, parametros);
            return resultado > 0;
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Alunos>> BuscarAlunosAsync()
    {
        try
        {
            string sql = "SELECT * FROM ALUNOS";
            return await _context.QueryAsync<Alunos>(sql);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RetornoPaginado<Alunos>> BuscarAlunosPaginadosAsync(int pagina, int quantidade)
    {
        try
        {
            string sqlAlunos = @"SELECT * FROM ALUNOS
                            ORDER BY ALUNOID
                            OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                Offset = (pagina -1) * quantidade,
                Quantidade = quantidade
            };

            var alunos = (await _context.QueryAsync<Alunos>(sqlAlunos, parametros)).ToList();

            foreach(var aluno in alunos)
            {
                string sqlCursos = "SELECT * FROM CURSOS C INNER JOIN MATRICULAS M ON C.CURSOID = M.CURSOID WHERE M.ALUNOID = @ALUNOID;";

                var cursos = await _context.QueryAsync<Cursos>(sqlCursos, new { AlunoId = aluno.AlunoId });
                aluno.Cursos = cursos.ToList();
            }

            var totalAlunos = "SELECT COUNT(*) FROM ALUNOS";
            var retornoTotalAlunos = await _context.ExecuteScalarAsync<int>(totalAlunos);

            if(!alunos.Any())
            {
                throw new Exception("nenhum registro encontrado nesta pagina");
            }

            return new RetornoPaginado<Alunos>() 
            {
                Pagina = pagina,
                QtdaPagina = quantidade,
                TotalRegistros = retornoTotalAlunos,
                Itens = alunos
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Alunos> BuscarAlunosPorIdAsync(int id)
    {
        try
        {
            string sql = "SELECT TOP 1 * FROM ALUNOS WHERE ALUNOID = @ID";
            var parametros = new { Id = id };
            return await _context.QueryFirstOrDefaultAsync<Alunos>(sql, parametros);
        }   
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeletarAlunosAsync(int id)
    {
        try
        {
            string sql = "DELETE FROM ALUNOS WHERE ALUNOID = @ID";
            var parametros = new { Id = id };
            var resultado = await _context.ExecuteAsync(sql, parametros);
            return resultado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

