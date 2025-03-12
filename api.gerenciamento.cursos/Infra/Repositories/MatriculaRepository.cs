using Dapper;
using api.gerenciamento.cursos.Domain;
using System.Data;
using api.gerenciamento.cursos.Infra.Interfaces;

namespace api.gerenciamento.cursos.Infra.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly IDbConnection _conn;

        public MatriculaRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public async Task<Matricula> BuscarMatriculaPorId(int id)
        {
            try
            {
                string sql = "SELECT * FROM MATRICULAS WHERE MATRICULAID = @Id";
                var matricula = await _conn.QueryFirstOrDefaultAsync<Matricula>(sql, new { Id = id });
                return matricula;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar matrícula por ID: {ex.Message}", ex);
            }
        }
        public async Task<List<Matricula>> BuscarTodasMatriculas()
        {
            try
            {
                string sql = "SELECT * FROM MATRICULAS";
                var matriculas = await _conn.QueryAsync<Matricula>(sql);
                return matriculas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todas as matrículas: {ex.Message}", ex);
            }
        }

        public async Task<bool> InserirMatricula(Matricula matricula)
        {
            try
            {
                string sql = @"
                    INSERT INTO MATRICULAS (AlunoID, CursoID, DataMatricula)
                    VALUES (@AlunoID, @CursoID, @DataMatricula)";

                var parametros = new
                {
                    AlunoID = matricula.AlunoID,
                    CursoID = matricula.CursoID,
                    DataMatricula = matricula.DataMatricula
                };

                var resultado = await _conn.ExecuteAsync(sql, parametros);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir matrícula: {ex.Message}", ex);
            }
        }

        
        public async Task<bool> ExcluirMatricula(int id)
        {
            try
            {
                string sql = "DELETE FROM MATRICULAS WHERE MATRICULAID = @Id";
                var resultado = await _conn.ExecuteAsync(sql, new { Id = id });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir matrícula: {ex.Message}", ex);
            }
        }
        public async Task<RetornoPaginadoMatricula<Matricula>> BuscarMatriculaPorPaginaAsync(int pagina, int quantidade)
        {
            try
            {
                string sql = @"
                    SELECT * FROM MATRICULAS 
                    ORDER BY MATRICULAID 
                    OFFSET @Offset ROWS 
                    FETCH NEXT @Quantidade ROWS ONLY";

                var parametros = new
                {
                    Offset = (pagina - 1) * quantidade,
                    Quantidade = quantidade
                };

                var matriculas = await _conn.QueryAsync<Matricula>(sql, parametros);

                string countSql = "SELECT COUNT(*) FROM MATRICULAS";
                var totalRegistros = await _conn.QueryFirstOrDefaultAsync<int>(countSql);

                return new RetornoPaginadoMatricula<Matricula>
                {
                    Pagina = pagina,
                    QtdPagina = quantidade,
                    TotalRegistros = totalRegistros,
                    Matriculas = matriculas.ToList()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar matrículas paginadas: {ex.Message}", ex);
            }
        }
    }
    }
