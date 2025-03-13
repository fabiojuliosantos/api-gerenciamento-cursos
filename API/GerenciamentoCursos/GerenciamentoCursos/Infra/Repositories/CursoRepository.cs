using System.Data;
using Dapper;
using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Infra.Interfaces;

namespace GerenciamentoCursos.Infra.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IDbConnection _connection;

        public CursoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> CriarCursoAsync(Curso curso)
        {
            try
            {
                string sql = @"INSERT INTO Cursos (Nome, Descricao, CargaHoraria)
                       OUTPUT INSERTED.CursoID
                       VALUES (@Nome, @Descricao, @CargaHoraria)";

                var parametros = new
                {
                    Nome = curso.Nome,
                    Descricao = curso.Descricao,
                    CargaHoraria = curso.CargaHoraria
                };

                int cursoId = await _connection.QuerySingleAsync<int>(sql, parametros);

                if (cursoId > 0)
                {
                    curso.CursoID = cursoId;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar curso.", ex);
            }
        }


        public async Task<bool> ExcluirCursoAsync(int id)
        {
            try
            {
                string sql = @"DELETE FROM Cursos WHERE CursoID = @CursoID";

                var parametros = new { CursoID = id };

                var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);
                return linhasAfetadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover curso.", ex);
            }
        }

        public async Task<Curso> BuscarCursoPorIdAsync(int id)
        {
            try
            {
                string sql = @"SELECT * FROM Cursos WHERE CursoID = @CursoID";

                return await _connection.QueryFirstOrDefaultAsync<Curso>(sql, new { CursoID = id });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar curso por ID.", ex);
            }
        }

        public async Task<List<Curso>> BuscarTodosCursosAsync()
        {
            try
            {
                string sql = @"SELECT * FROM Cursos";

                var cursos = await _connection.QueryAsync<Curso>(sql);
                return cursos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os cursos.", ex);
            }
        }

        public async Task<bool> AtualizarCursoAsync(int id, Curso curso)
        {
            try
            {
                string sql = @"UPDATE Cursos 
                               SET Nome = @Nome, Descricao = @Descricao, CargaHoraria = @CargaHoraria
                               WHERE CursoID = @CursoID";

                var parametros = new
                {
                    CursoID = id,
                    Nome = curso.Nome,
                    Descricao = curso.Descricao,
                    CargaHoraria = curso.CargaHoraria
                };

                var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);
                return linhasAfetadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar curso.", ex);
            }
        }
    }
}
