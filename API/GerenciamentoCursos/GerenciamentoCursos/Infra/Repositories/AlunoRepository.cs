using System.Data;
using Dapper;
using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Infra.Interfaces;

namespace GerenciamentoCursos.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDbConnection _connection;

        public AlunoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> CriarAlunoAsync(Aluno aluno)
        {
            try
            {
                string sql = @"INSERT INTO Alunos (Nome, Idade, Email, DataMatricula) 
                               VALUES (@Nome, @Idade, @Email, @DataMatricula)";

                var parametros = new
                {
                    Nome = aluno.Nome,
                    Idade = aluno.Idade,
                    Email = aluno.Email,
                    DataMatricula = aluno.DataMatricula
                };

                var alunoCadastrado = await _connection.ExecuteAsync(sql, parametros);
                return alunoCadastrado > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar aluno.", ex);
            }
        }

        public async Task<bool> ExcluirAlunoAsync(int id)
        {
            try
            {
                string sql = @"DELETE FROM Alunos WHERE AlunoID = @AlunoID";

                var parametros = new { AlunoID = id };

                var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);
                return linhasAfetadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir aluno.", ex);
            }
        }

        public async Task<Aluno> BuscarAlunoPorIdAsync(int id)
        {
            try
            {
                string sql = @"SELECT * FROM Alunos WHERE AlunoID = @AlunoID";

                return await _connection.QueryFirstOrDefaultAsync<Aluno>(sql, new { AlunoID = id });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar aluno por ID.", ex);
            }
        }

        public async Task<List<Aluno>> BuscarTodosAlunosAsync()
        {
            try
            {
                string sql = @"SELECT * FROM Alunos";

                var alunos = await _connection.QueryAsync<Aluno>(sql);
                return alunos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os alunos.", ex);
            }
        }

        public async Task<RetornoPaginado<Aluno>> BuscarAlunosPaginadosAsync(int pagina, int quantidade)
        {
            try
            {
                string sql = @"SELECT * FROM Alunos ORDER BY AlunoID 
                       OFFSET @Offset ROWS FETCH NEXT @Quantidade ROWS ONLY";

                string countSql = @"SELECT COUNT(*) FROM Alunos";

                var parametros = new
                {
                    Offset = (pagina - 1) * quantidade,
                    Quantidade = quantidade
                };

                var alunos = await _connection.QueryAsync<Aluno>(sql, parametros);
                var totalRegistros = await _connection.ExecuteScalarAsync<int>(countSql);

                return new RetornoPaginado<Aluno>(alunos.ToList(), totalRegistros, pagina, quantidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar alunos paginados.", ex);
            }
        }




        public async Task<bool> AtualizarAlunoAsync(int id, Aluno aluno)
        {
            try
            {
                string sql = @"UPDATE Alunos 
                               SET Nome = @Nome, Idade = @Idade, Email = @Email, DataMatricula = @DataMatricula
                               WHERE AlunoID = @AlunoID";

                var parametros = new
                {
                    AlunoID = id,
                    Nome = aluno.Nome,
                    Idade = aluno.Idade,
                    Email = aluno.Email,
                    DataMatricula = aluno.DataMatricula
                };

                var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);
                return linhasAfetadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar aluno.", ex);
            }
        }
    }
}
