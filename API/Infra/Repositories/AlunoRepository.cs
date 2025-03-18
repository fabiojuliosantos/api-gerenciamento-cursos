using System.Data;
using Api.Domain;
using Api.Infra.Dto;
using Api.Infra.Interfaces;
using Api.Utils;
using Dapper;

namespace Api.Infra.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly IDbConnection _conn;

    public AlunoRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    /*
        Checar as buscas de alunos, a rota de listar todos s alunos não exibe as informações dos cursos, 
        enquanto a rota de exibir o aluno por id não exibe a descrição e a cargaHoraria do curso
    */
    public async Task<RetornoPaginado<Aluno>> ListaAlunosPaginados(int pagina, int quantidade)
    {
        try
        {
            string sql = "SELECT * FROM ALUNOS ORDER BY ALUNOID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";
    
            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                QUANTIDADE = quantidade,
            };
    
            var alunos = await _conn.QueryAsync<Aluno>(sql, parametros);

            var consultaTotalAlunos = "SELECT COUNT(*) FROM ALUNOS";
    
            var totalAlunos = await _conn.ExecuteScalarAsync<int>(consultaTotalAlunos);
    
            return new RetornoPaginado<Aluno>()
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = totalAlunos,
                ListaDados = [.. alunos],
            };
        }
        catch (Exception) { throw; }
    }
    
    public async Task<List<Aluno>> ListaTodosAlunos()
    {
        try
        {
            string sql = @"SELECT * FROM ALUNOS";
            var alunos = await _conn.QueryAsync<Aluno>(sql);
            return alunos.ToList();
        }
        catch (Exception) { throw; }
    }

    public async Task<Aluno> BuscaAlunoPorId(int id)
    {
        try
        {
            string sql = @"SELECT TOP 1 * FROM ALUNOS WHERE ALUNOID = @ID";

            var parametros = new
            {
                ID = id
            };
            
            var aluno = await _conn.QueryFirstOrDefaultAsync<Aluno>(sql, parametros);

            return aluno;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> CriaAluno(Aluno aluno)
    {
        try
        {
            string sql = "INSERT INTO ALUNOS VALUES (@NOME, @IDADE, @EMAIL, @DATAMATRICULA)";
            
            var parametros = new
            {
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email,
                DATAMATRICULA = aluno.DataMatricula
            };
    
            var result = await _conn.ExecuteAsync(sql, parametros);
    
            return result > 0;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> AtualizaAluno(Aluno aluno)
    {
        try
        {
            string sql = @"UPDATE ALUNOS SET NOME = @NOME, IDADE = @IDADE, EMAIL = @EMAIL, DATAMATRICULA = @DATAMATRICULA WHERE ALUNOID = @ID";
            
            var parametros = new
            {
                ID = aluno.AlunoID,
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email,
                DATAMATRICULA = aluno.DataMatricula
            };

            var result = await _conn.ExecuteAsync(sql, parametros);

            return result > 0;
      
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> DeletaAluno(int id)
    {
        string sql = @"DELETE  FROM ALUNOS WHERE ALUNOID = @ID";

        var parametros = new 
        {
            ID = id
        };

        var result = await _conn.ExecuteAsync(sql, parametros);

        return result > 0;
    }

}