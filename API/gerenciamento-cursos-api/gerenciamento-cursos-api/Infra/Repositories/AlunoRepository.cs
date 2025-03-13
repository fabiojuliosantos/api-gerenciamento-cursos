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
                EMAIL = aluno.Email,
                ID = aluno.AlunoID
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
            var sql = $"SELECT TOP 1 * FROM ALUNOS WHERE ALUNOID = {id}";

            var aluno = await _connection.QueryFirstOrDefaultAsync<Aluno>(sql);

            var sql2 = $"SELECT * FROM MATRICULAS M INNER JOIN CURSOS C ON M.CURSOID=C.CURSOID WHERE ALUNOID={aluno.AlunoID}";

            var curso = await _connection.QueryAsync<Curso>(sql2);

            aluno.Cursos = curso.ToList();

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

            foreach (var aluno in alunos)
            {
                var sql2 = $"SELECT * FROM MATRICULAS M INNER JOIN CURSOS C ON M.CURSOID=C.CURSOID WHERE ALUNOID={aluno.AlunoID}";

                var curso = await _connection.QueryAsync<Curso>(sql2);

                aluno.Cursos = curso.ToList();
            }

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

            foreach (var aluno in alunos)
            {
                var sql3 = $"SELECT * FROM MATRICULAS M INNER JOIN CURSOS C ON M.CURSOID=C.CURSOID WHERE ALUNOID={aluno.AlunoID}";

                var curso = await _connection.QueryAsync<Curso>(sql3);

                aluno.Cursos = curso.ToList();
            }

            return alunos.ToList();
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> ExcluirAluno(int id)
    {
        try
        {
            string sql = $"DELETE FROM MATRICULAS WHERE ALUNOID={id}";

            var matriculaExcluida = await _connection.ExecuteAsync(sql);
            if(matriculaExcluida > 0)
            {
                string sql2 = $"DELETE FROM ALUNOS WHERE ALUNOID={id}";

                var alunoExcluido = await _connection.ExecuteAsync(sql2);

                return alunoExcluido > 0 ? true : false;
            }
            return false;
            
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> InserirAluno(Aluno aluno)
    {
        try
        {
            Validacoes validacao = new(new AlunoRepository(_connection));

            if (!validacao.ValidaEmail(aluno.Email))
                throw new Exception("Email inserido inválido!");

            string sql = $"INSERT INTO ALUNOS VALUES (@NOME, @IDADE, @EMAIL, @DATAMATRICULA)";

            var parametros = new
            {
                NOME = aluno.Nome,
                IDADE = aluno.Idade,
                EMAIL = aluno.Email,
                DATAMATRICULA = DateTime.Now
            };

            var alunoCadastrado = await _connection.ExecuteAsync(sql, parametros);

            return alunoCadastrado > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }
}
