using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Infra.Interfaces;
using Dapper;
using System.Data;

namespace api.gerenciamento.cursos.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDbConnection _conn;

        public AlunoRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<Aluno> BuscarAlunoPorId(int id)
        {
            try
            {
                string sql = 
                    @" SELECT a.ALUNOID, a.NOME,a.IDADE,  a.EMAIL,  a.DATAMATRICULA, a.MATRICULAID, 
                    c.CURSOID, 
                    COALESCE(c.NOME, 'Curso sem nome') AS Nome, 
                        c.DESCRICAO, c.CARGAHORARIA
                    FROM ALUNOS a
                    LEFT JOIN MATRICULAS m ON a.ALUNOID = m.ALUNOID
                    LEFT JOIN CURSOS c ON m.CURSOID = c.CURSOID
                    WHERE a.ALUNOID = @Id";

                var alunos = new List<Aluno>();

                await _conn.QueryAsync<Aluno, Curso, Aluno>(
                    sql,
                    (aluno, curso) =>
                    {
                        var alunoExistente = alunos.FirstOrDefault(a => a.AlunoID == aluno.AlunoID);
                        if (alunoExistente == null)
                        {
                            alunoExistente = aluno;
                            alunoExistente.Cursos = new List<Curso>();
                            alunos.Add(alunoExistente);
                        }

                        if (curso != null)
                        {
                            alunoExistente.Cursos.Add(curso);
                        }

                        return alunoExistente;
                    },
                    new { Id = id },
                    splitOn: "CURSOID"
                );

                return alunos.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve erro ao buscar aluno por ID: {ex.Message}", ex);
            }
        }
        public async Task<List<Aluno>> BuscarTodosAlunos()
        {
            //Checar o uso de Left Join, e outras maneiras de retornar todos os alunos
            try
            {
                string sql = 
                    @"SELECT a.ALUNOID, a.NOME, a.IDADE, a.EMAIL, a.DATAMATRICULA, a.MATRICULAID,
                    c.CURSOID, 
                    COALESCE(c.NOME, 'Curso sem nome') AS Nome, c.DESCRICAO, c.CARGAHORARIA
                    FROM ALUNOS a
                    LEFT JOIN MATRICULAS m ON a.ALUNOID = m.ALUNOID
                    LEFT JOIN CURSOS c ON m.CURSOID = c.CURSOID";

                var alunos = new List<Aluno>();

                await _conn.QueryAsync<Aluno, Curso, Aluno>(
                    sql,
                    (aluno, curso) =>
                    {
                        var alunoExistente = alunos.FirstOrDefault(a => a.AlunoID == aluno.AlunoID);
                        if (alunoExistente == null)
                        {
                            alunoExistente = aluno;
                            alunoExistente.Cursos = new List<Curso>();
                            alunos.Add(alunoExistente);
                        }

                        if (curso != null)
                        {
                            alunoExistente.Cursos.Add(curso);
                        }
                        return alunoExistente;
                    },
                    splitOn: "CURSOID"
                );
                return alunos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve erro ao buscar todos os alunos: {ex.Message}", ex);
            }
        }

        //O retorno paginado não traz os cursos de cada aluno. A busca apenas retorna os dados dos alunos.
        public async Task<RetornoPaginadoAluno<Aluno>> BuscarAlunosPorPagina(int pagina, int quantidade)
        {
            try
            {

                string sql = @"
                    SELECT * FROM ALUNOS
                    ORDER BY ALUNOID
                    OFFSET @Offset ROWS
                    FETCH NEXT @Quantidade ROWS ONLY";

                var parametros = new
                {
                    Offset = (pagina - 1) * quantidade,
                    Quantidade = quantidade
                };

                var alunos = await _conn.QueryAsync<Aluno>(sql, parametros);
                var totalRegistros = await _conn.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM ALUNOS");

                //Retornando o resultado paginado
                return new RetornoPaginadoAluno<Aluno>
                {
                    TotalRegistros = totalRegistros,
                    Pagina = pagina,
                    QtdPagina = quantidade,
                    Alunos = alunos.ToList()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve erro ao buscar alunos paginados: {ex.Message}", ex);
            }
        }
        public async Task<bool> InserirAluno(Aluno aluno)
        {
            try
            {
                string sql = "INSERT INTO ALUNOS (NOME, IDADE, EMAIL, DATAMATRICULA) VALUES (@NOME, @IDADE, @EMAIL, @DATAMATRICULA)";

                var parametros = new
                {
                    NOME = aluno.Nome,
                    IDADE = aluno.Idade,
                    EMAIL = aluno.Email,
                    DATAMATRICULA = aluno.DataMatricula
                };

                var alunoCadastrado = await _conn.ExecuteAsync(sql, parametros);
                return alunoCadastrado > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve um erro ao inserir aluno: {ex.Message}", ex);
            }
        }
        public async Task<bool> AtualizarAluno(Aluno aluno)
        {
            try
            {
                string sql = @"
                    UPDATE ALUNOS 
                    SET NOME = @Nome, IDADE = @Idade, EMAIL = @Email, DATAMATRICULA = @DataMatricula
                    WHERE ALUNOID = @AlunoID";

                var result = await _conn.ExecuteAsync(sql, aluno);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve um erro ao atualizar aluno: {ex.Message}", ex);
            }
        }
        public async Task<bool> ExcluirAluno(int id)
        {
            try
            {
                string sql = "DELETE FROM ALUNOS WHERE ALUNOID = @Id";
                var result = await _conn.ExecuteAsync(sql, new { Id = id });
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve um erro ao excluir aluno: {ex.Message}", ex);
            }
        }
    }
}


