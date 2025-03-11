using System.Data;
using Dapper;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Infra.Interfaces;
using gerenciamento_cursos_api.Validacao;

namespace gerenciamento_cursos_api.Infra.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly IDbConnection _connection;

    public AlunoRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> AtualizarAluno(Aluno aluno)
    {
        try
        {
            string sql = "UPDATE ALUNOS SET NOME=@NOME, IDADE=@IDADE, EMAIL=@EMAIL WHERE ALUNOID=@ID";
            var parametros = new
            {
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email
            };

            var alunoAtualizado = await _connection.ExecuteAsync(sql, parametros);

            return alunoAtualizado > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Aluno> BuscarAlunoId(int id)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM ALUNOS WHERE ALUNOID = {id}";
            var aluno = await _connection.QueryFirstOrDefaultAsync<Aluno>(sql);
            return aluno;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<RetornoPaginado<Aluno>> BuscarAlunosPagina(int pagina, int qtdRegistros)
    {
        try
        {
            Validacoes validacao = new(new AlunoRepository(_connection));

            string sql = "SELECT * FROM ALUNOS ORDER BY ALUNOID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * qtdRegistros,
                QUANTIDADE = qtdRegistros,
            };

            var alunos = await _connection.QueryAsync<Aluno>(sql, parametros);

            var totalAlunos = "SELECT COUNT(*) FROM ALUNOS";

            var retornoTotalAlunos = await _connection.ExecuteScalarAsync<int>(totalAlunos);

            if (validacao.VerificaPaginaVazia(pagina, qtdRegistros, retornoTotalAlunos)) 
            {
                return new RetornoPaginado<Aluno>()
                {
                    Pagina = pagina,
                    QtdPagina = qtdRegistros,
                    TotalRegistros = retornoTotalAlunos,
                    Registros = alunos.ToList(),
                    Mensagem = "Não foram encontrados registros nesta página!"
                };
            }
            else
            {
                return new RetornoPaginado<Aluno>()
                {
                    Pagina = pagina,
                    QtdPagina = qtdRegistros,
                    TotalRegistros = retornoTotalAlunos,
                    Registros = alunos.ToList(),
                    Mensagem = $"Foram encontrados {alunos.Count()} alunos nesta página!"
                };
            }
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Aluno>> BuscarTodosAlunos()
    {
        try
        {
            string sql = "SELECT * FROM ALUNOS";
            var alunos = await _connection.QueryAsync<Aluno>(sql);

            return alunos.ToList();
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> ExcluirAluno(int id)
    {
        try
        {
            string sql = $"DELETE FROM ALUNOS WHERE ALUNOSID={id}";

            var alunoExcluido = await _connection.ExecuteAsync(sql);

            return alunoExcluido > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> InserirAluno(Aluno aluno)
    {
        try
        {
            string sql = $"INSERT INTO ALUNOS VALUES (@NOME, @IDADE, @EMAIL)";

            var parametros = new
            {
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email
            };

            var alunoCadastrado = await _connection.ExecuteAsync(sql, parametros);

            return alunoCadastrado > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }
}
