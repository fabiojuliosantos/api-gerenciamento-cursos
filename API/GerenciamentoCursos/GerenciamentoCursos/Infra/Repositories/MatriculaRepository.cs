using System.Data;
using Dapper;
using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Infra.Interfaces;

namespace GerenciamentoCursos.Infra.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly IDbConnection _connection;

        public MatriculaRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<RetornoPaginado<Matricula>> BuscarMatriculasPaginadasAsync(int pagina, int quantidade)
        {
            try
            {
                string sql = @"
                    SELECT m.MatriculaID, m.AlunoID, m.CursoID, m.DataMatricula, 
                           a.Nome AS AlunoNome, a.Email AS AlunoEmail, 
                           c.Nome AS CursoNome, c.Descricao AS CursoDescricao
                    FROM Matriculas m
                    INNER JOIN Alunos a ON m.AlunoID = a.AlunoID
                    INNER JOIN Cursos c ON m.CursoID = c.CursoID
                    ORDER BY m.MatriculaID
                    OFFSET @Offset ROWS 
                    FETCH NEXT @Quantidade ROWS ONLY";

                string countSql = @"SELECT COUNT(*) FROM Matriculas";

                var parametros = new
                {
                    Offset = (pagina - 1) * quantidade,
                    Quantidade = quantidade
                };

                var matriculas = await _connection.QueryAsync<Matricula>(sql, parametros);
                var totalRegistros = await _connection.ExecuteScalarAsync<int>(countSql);

                return new RetornoPaginado<Matricula>(matriculas.ToList(), totalRegistros, pagina, quantidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar matrículas paginadas.", ex);
            }
        }

        public async Task<bool> CriarMatriculaAsync(Matricula matricula)
        {
            try
            {
                string sql = @"
            INSERT INTO Matriculas (AlunoID, CursoID, DataMatricula) 
            OUTPUT INSERTED.MatriculaID
            VALUES (@AlunoID, @CursoID, @DataMatricula)";

                var parametros = new
                {
                    AlunoID = matricula.AlunoID,
                    CursoID = matricula.CursoID,
                    DataMatricula = matricula.DataMatricula
                };

                int matriculaId = await _connection.QuerySingleAsync<int>(sql, parametros);

                matricula.MatriculaID = matriculaId;

                return matriculaId > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar matrícula.", ex);
            }
        }

        //Quando tiver apenas um parâmetro, pode usar o string.Format() para evitar o uso da variavel de parametros
        public async Task<bool> ExcluirMatriculaAsync(int id)
        {
            try
            {
                string sql = @"DELETE FROM Matriculas WHERE MatriculaID = @MatriculaID";

                var parametros = new { MatriculaID = id };

                var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);
                return linhasAfetadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover matrícula.", ex);
            }
        }
    }
}
