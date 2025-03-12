using Dapper;
using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Infra.Interfaces;
using System.Data;

namespace api.gerenciamento.cursos.Infra.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IDbConnection _conn;

        public CursoRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public async Task<Curso> BuscarCursoPorId(int id)
        {
            try
            {
                string sql = $"SELECT TOP 1 * FROM CURSOS WHERE CURSOID={id}";
                var curso = await _conn.QueryFirstOrDefaultAsync<Curso>(sql);
                return curso;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Curso>> BuscarTodosCursos()
        {
            try
            {
                string sql = "SELECT * FROM CURSOS";
                var cursos = await _conn.QueryAsync<Curso>(sql);
                return cursos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> InserirCurso(Curso curso)
        {
            try
            {
                string sql = "INSERT INTO CURSOS (NOME, DESCRICAO, CARGAHORARIA) VALUES(@Nome, @Descricao, @CargaHoraria)";

                var parametros = new
                {
                    Nome = curso.Nome,
                    Descricao = curso.Descricao,
                    CargaHoraria = curso.CargaHoraria
                };

                var cursoCadastrado = await _conn.ExecuteAsync(sql, parametros);

                return cursoCadastrado > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> AtualizarCurso(Curso curso)
        {
            try
            {
                string sql = "UPDATE CURSOS SET NOME=@Nome, DESCRICAO=@Descricao, CARGAHORARIA=@CargaHoraria WHERE CURSOID=@CursoID";
                var parametros = new
                {
                    Nome = curso.Nome,
                    Descricao = curso.Descricao,
                    CargaHoraria = curso.CargaHoraria,
                    CursoID = curso.CursoID
                };
                var cursoAtualizado = await _conn.ExecuteAsync(sql, parametros);
                return cursoAtualizado > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ExcluirCurso(int id)
        {
            try
            {
                string sql = "DELETE FROM CURSOS WHERE CURSOID=@Id";
                var cursoExcluido = await _conn.ExecuteAsync(sql, new { Id = id });
                return cursoExcluido > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<RetornoPaginadoCurso<Curso>> BuscarCursosPorPaginaAsync(int pagina, int quantidade)
        {
            try
            {
                string sql = "SELECT * FROM CURSOS ORDER BY CURSOID OFFSET @Offset ROWS FETCH NEXT @Quantidade ROWS ONLY";

                var parametros = new
                {
                    Offset = (pagina - 1) * quantidade,
                    Quantidade = quantidade
                };

                var cursos = await _conn.QueryAsync<Curso>(sql, parametros);

                string countSql = "SELECT COUNT(*) FROM CURSOS";
                var totalRegistros = await _conn.QueryFirstOrDefaultAsync<int>(countSql);

                return new RetornoPaginadoCurso<Curso>
                {
                    Pagina = pagina,
                    QtdPagina = quantidade,
                    TotalRegistros = totalRegistros,
                    Cursos = cursos.ToList()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
