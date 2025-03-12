using System.Data;
using Dapper;
using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Dto;
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
                string sql = @"
            INSERT INTO Alunos (Nome, Idade, Email, DataMatricula) 
            OUTPUT INSERTED.AlunoID
            VALUES (@Nome, @Idade, @Email, @DataMatricula)";

                var parametros = new
                {
                    Nome = aluno.Nome,
                    Idade = aluno.Idade,
                    Email = aluno.Email,
                    DataMatricula = aluno.DataMatricula
                };

                var alunoID = await _connection.ExecuteScalarAsync<int>(sql, parametros);

                if (alunoID > 0)
                {
                    aluno.AlunoID = alunoID;
                    return true;
                }

                return false;
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
                string sql = @"
        SELECT 
            a.AlunoID,
            a.Nome,
            a.Idade,
            a.Email,
            a.DataMatricula,
            c.CursoID,
            COALESCE(c.Nome, 'Curso sem nome') AS Nome,
            c.Descricao,
            c.CargaHoraria
        FROM 
            Alunos a
        LEFT JOIN 
            Matriculas m ON a.AlunoID = m.AlunoID
        LEFT JOIN 
            Cursos c ON m.CursoID = c.CursoID
        WHERE 
            a.AlunoID = @AlunoID;";

                var alunoDicionario = new Dictionary<int, Aluno>();

                var alunoComCursos = await _connection.QueryAsync<Aluno, Curso, Aluno>(
                    sql,
                    (aluno, curso) =>
                    {
                        if (!alunoDicionario.TryGetValue(aluno.AlunoID, out var alunoExistente))
                        {
                            alunoExistente = aluno;
                            alunoExistente.Cursos = new List<Curso>();
                            alunoDicionario.Add(aluno.AlunoID, alunoExistente);
                        }

                        if (curso != null && curso.CursoID > 0)
                        {
                            alunoExistente.Cursos.Add(curso);
                        }

                        return alunoExistente;
                    },
                    new { AlunoID = id },
                    splitOn: "CursoID"
                );

                return alunoDicionario.Values.FirstOrDefault();
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
                string sql = @"
        SELECT 
            a.AlunoID,
            a.Nome,
            a.Idade,
            a.Email,
            a.DataMatricula,
            c.CursoID,
            COALESCE(c.Nome, 'Curso sem nome') AS Nome,
            c.Descricao,
            c.CargaHoraria
        FROM 
            Alunos a
        LEFT JOIN 
            Matriculas m ON a.AlunoID = m.AlunoID
        LEFT JOIN 
            Cursos c ON m.CursoID = c.CursoID;";

                var alunoDicionario = new Dictionary<int, Aluno>();

                var alunos = await _connection.QueryAsync<Aluno, Curso, Aluno>(
                    sql,
                    (aluno, curso) =>
                    {
                        if (!alunoDicionario.TryGetValue(aluno.AlunoID, out var alunoExistente))
                        {
                            alunoExistente = aluno;
                            alunoExistente.Cursos = new List<Curso>();
                            alunoDicionario.Add(aluno.AlunoID, alunoExistente);
                        }

                        if (curso != null && curso.CursoID > 0)
                        {
                            alunoExistente.Cursos.Add(curso);
                        }

                        return alunoExistente;
                    },
                    splitOn: "CursoID"
                );

                return alunoDicionario.Values.ToList();
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
                string sql = @"
        SELECT 
            a.AlunoID,
            a.Nome,
            a.Idade,
            a.Email,
            a.DataMatricula,
            c.CursoID,
            COALESCE(c.Nome, 'Curso sem nome') AS Nome,
            c.Descricao,
            c.CargaHoraria
        FROM 
            Alunos a
        LEFT JOIN 
            Matriculas m ON a.AlunoID = m.AlunoID
        LEFT JOIN 
            Cursos c ON m.CursoID = c.CursoID
        ORDER BY a.AlunoID
        OFFSET @Offset ROWS FETCH NEXT @Quantidade ROWS ONLY;";

                string countSql = "SELECT COUNT(*) FROM Alunos";

                var parametros = new
                {
                    Offset = (pagina - 1) * quantidade,
                    Quantidade = quantidade
                };

                var alunoDicionario = new Dictionary<int, Aluno>();

                var alunos = await _connection.QueryAsync<Aluno, Curso, Aluno>(
                    sql,
                    (aluno, curso) =>
                    {
                        if (!alunoDicionario.TryGetValue(aluno.AlunoID, out var alunoExistente))
                        {
                            alunoExistente = aluno;
                            alunoExistente.Cursos = new List<Curso>();
                            alunoDicionario.Add(aluno.AlunoID, alunoExistente);
                        }

                        if (curso != null && curso.CursoID > 0)
                        {
                            alunoExistente.Cursos.Add(curso);
                        }

                        return alunoExistente;
                    },
                    parametros,
                    splitOn: "CursoID"
                );

                var totalRegistros = await _connection.ExecuteScalarAsync<int>(countSql);

                return new RetornoPaginado<Aluno>(alunoDicionario.Values.ToList(), totalRegistros, pagina, quantidade);
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
                       SET Nome = @Nome, Idade = @Idade, Email = @Email
                       WHERE AlunoID = @AlunoID";

                var parametros = new
                {
                    Nome = aluno.Nome,
                    Idade = aluno.Idade,
                    Email = aluno.Email,
                    AlunoID = id
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
