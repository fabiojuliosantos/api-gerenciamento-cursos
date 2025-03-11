using System.Data;
using Dapper;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Infra.Interfaces;
using gerenciamento_cursos_api.Validacao;

namespace gerenciamento_cursos_api.Infra.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly IDbConnection _connection;

    public CursoRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> AtualizarCurso(Curso curso)
    {
        try
        {
            string sql = "UPDATE CURSOS SET NOME=@NOME, DESCRICAO=@DESCRICAO WHERE CURSOID=@ID";
            var parametros = new
            {
                NOME = curso.Nome,
                DESCRICAO = curso.Descricao
            };

            var cursoAtualizado = await _connection.ExecuteAsync(sql, parametros);

            return cursoAtualizado > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Curso> BuscarCursoId(int id)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM CURSOS WHERE CURSOID = {id}";
            var curso = await _connection.QueryFirstOrDefaultAsync<Curso>(sql);
            return curso;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<RetornoPaginado<Curso>> BuscarCursosPagina(int pagina, int qtdRegistros)
    {
        try
        {
            Validacoes validacao = new(new CursoRepository(_connection));

            string sql = "SELECT * FROM CURSOS ORDER BY CURSOID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * qtdRegistros,
                QUANTIDADE = qtdRegistros,
            };

            var cursos = await _connection.QueryAsync<Curso>(sql, parametros);

            var totalCursos = "SELECT COUNT(*) FROM ALUNOS";

            var retornoTotalCursos = await _connection.ExecuteScalarAsync<int>(totalCursos);

            if (validacao.VerificaPaginaVazia(pagina, qtdRegistros, retornoTotalCursos))
            {
                return new RetornoPaginado<Curso>()
                {
                    Pagina = pagina,
                    QtdPagina = qtdRegistros,
                    TotalRegistros = retornoTotalCursos,
                    Registros = cursos.ToList(),
                    Mensagem = "Não foram encontrados registros nesta página!"
                };
            }
            else
            {
                return new RetornoPaginado<Curso>()
                {
                    Pagina = pagina,
                    QtdPagina = qtdRegistros,
                    TotalRegistros = retornoTotalCursos,
                    Registros = cursos.ToList(),
                    Mensagem = $"Foram encontrados {cursos.Count()} cursos nesta página!"
                };
            }
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Curso>> BuscarTodosCursos()
    {
        string sql = "SELECT * FROM CURSOS";

        var cursos = await _connection.QueryAsync<Curso>(sql);

        return cursos.ToList();
    }

    public async Task<bool> InserirCurso(Curso curso)
    {
        try
        {
            string sql = $"INSERT INTO CURSOS VALUES (@NOME, @DESCRICAO)";

            var parametros = new
            {
                NOME = curso.Nome,
                DESCRICAO = curso.Descricao,
            };

            var cursoCadastrado = await _connection.ExecuteAsync(sql, parametros);

            return cursoCadastrado > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> RemoverCurso(int id)
    {
        try
        {
            string sql = $"DELETE FROM CURSOS WHERE CURSOID={id}";

            var cursoExcluido = await _connection.ExecuteAsync(sql);

            return cursoExcluido > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }
}
