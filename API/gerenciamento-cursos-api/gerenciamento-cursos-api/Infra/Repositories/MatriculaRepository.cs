using System.Data;
using Dapper;
using gerenciamento_cursos_api.Domain.Entities;
using gerenciamento_cursos_api.Infra.Interfaces;
using gerenciamento_cursos_api.Validacao;

namespace gerenciamento_cursos_api.Infra.Repositories;

public class MatriculaRepository : IMatriculaRepository
{
    private readonly IDbConnection _connection;

    public MatriculaRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<RetornoPaginado<Matricula>> BuscarMatriculaPagina(int pagina, int qtdRegistros)
    {
        try
        {
            Validacoes validacao = new(new CursoRepository(_connection));

            string sql = "SELECT * FROM MATRICULAS ORDER BY MATRICULAID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * qtdRegistros,
                QUANTIDADE = qtdRegistros,
            };

            var matriculas = await _connection.QueryAsync<Matricula>(sql, parametros);

            var totalMatriculas = "SELECT COUNT(*) FROM MATRICULAS";

            var retornoTotalMatriculas = await _connection.ExecuteScalarAsync<int>(totalMatriculas);

            if (validacao.VerificaPaginaVazia(pagina, qtdRegistros, retornoTotalMatriculas))
            {
                return new RetornoPaginado<Matricula>()
                {
                    Pagina = pagina,
                    QtdPagina = qtdRegistros,
                    TotalRegistros = retornoTotalMatriculas,
                    Registros = matriculas.ToList(),
                    Mensagem = "Não foram encontrados registros nesta página!"
                };
            }
            else
            {
                return new RetornoPaginado<Matricula>()
                {
                    Pagina = pagina,
                    QtdPagina = qtdRegistros,
                    TotalRegistros = retornoTotalMatriculas,
                    Registros = matriculas.ToList(),
                    Mensagem = $"Foram encontradas {matriculas.Count()} matriculas nesta página!"
                };
            }
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> CancelarMatricula(int id)
    {
        string sql = $"DELETE FROM MATRICULAS WHERE MATRICULAID={id}";

        var matriculaCancelada = await _connection.ExecuteAsync(sql);

        return matriculaCancelada > 0 ? true : false;
    }

    public async Task<bool> MatricularAluno(Matricula matricula)
    {
        try
        {
            string sql = $"INSERT INTO MATRICULAS VALUES (@ALUNOID, @CURSOID, @DATAMATRICULA)";

            var parametros = new
            {
                ALUNOID = matricula.AlunoID,
                CURSOID = matricula.CursoID,
                DATAMATRICULA = DateTime.Now
            };

            var matriculaAluno = await _connection.ExecuteAsync(sql, parametros);

            return matriculaAluno > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }
}
