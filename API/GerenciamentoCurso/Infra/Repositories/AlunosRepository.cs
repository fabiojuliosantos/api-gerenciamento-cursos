using System.Data;
using AutoMapper;
using Dapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Infra.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GerenciamentoCurso.Infra.Repositories;

public class AlunosRepository : IAlunoRepository
{
    private readonly IDbConnection _conn;
    private readonly IMapper _mapper;

    public AlunosRepository(IDbConnection conn, IMapper mapper)
    {
        _conn = conn;
        _mapper = mapper;
    }

    public async Task<bool> AtualizarAluno(Alunos alunos)
    {
        try
        {
            string sql = "UPDATE ALUNOS SET NOME = NOME, EMAIL = @EMAIL, IDADE = @IDADE, DATAMATRICULA = DATAMATRICULA WHERE ALUNOID = @ALUNOID";
            var parametros = new {
            
                alunos.Nome,
                alunos.Email,
                alunos.Idade,
                alunos.DataMatricula
            };

            var resultado = await _conn.ExecuteAsync(sql, parametros);

            return resultado > 0;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Alunos> BuscasrAlunosPorId(int id)
    {
        try
        {
            string sql = $"select * from alunos WHERE ALUNOID = {id}";
            var resultado = await _conn.QueryFirstOrDefault(sql);


            return resultado;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> CriarAluno(Alunos alunos)
    {
        try
        {
            string sql = "insert into alunos(NOME,IDADE,EMAIL,DATAMATRICULA) values(@NOME,@IDADE,@EMAIL,@DATAMATRICULA)";
            var parametros = new
            {
            alunos.Nome,
            alunos.Idade,
            alunos.Email,
            alunos.DataMatricula
            };

            var resultado = await _conn.ExecuteAsync(sql, parametros);

            return resultado > 0;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> DeletarAluno(int id)
    {
        try
        {
            string sql = $"DELETE FROM ALUNOS WHERE ALUNOID = {id}";
            var resultado = await _conn.ExecuteAsync(sql);

            return resultado > 0;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<IEnumerable<Alunos>> RecuperarTodosAlunos()
    {
        try
        {
            string sql = "SELECT * FROM ALUNOS";
            var resultado = await _conn.QueryFirstOrDefault(sql);
            return resultado;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<RetornoPaginado<Alunos>> RetornoPaginadoAluno(int pagina, int quantidade)
    {
        try
        {
            string sql = "SELECT * FROM ALUNOS ORDER BY ALUNOID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY ";

            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,

                QUANTIDADE = quantidade
            };

            var alunos = await _conn.QueryAsync<Alunos>(sql, parametros);

            var totalAlunos = "SELECT COUNT(*) FROM ALUNOS ";

            var retornoTotalAlunos = await _conn.ExecuteScalarAsync<int>(totalAlunos);

            return new RetornoPaginado<Alunos>()
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistro = retornoTotalAlunos,
                Retorno = alunos.ToList()

            };
        }
        catch (Exception)
        {

            throw;
        }
    }
}
