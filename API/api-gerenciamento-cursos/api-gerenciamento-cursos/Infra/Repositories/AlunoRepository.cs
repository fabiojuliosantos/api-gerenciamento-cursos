using System.Data;
using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Infra.Interfaces;
using AutoMapper;
using Dapper;

namespace api_gerenciamento_cursos.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDbConnection _connection;
        private readonly IMapper _mapper;

        public AlunoRepository(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }
        public async Task<bool> AdicionaAlunoAsync(Aluno aluno)
        {
            string sql = "INSERT INTO ALUNOS (Nome, Idade, Email) VALUES (@Nome, @Idade, @Email)";

            var parametros = new
            {
                aluno.Nome,
                aluno.Idade,
                aluno.Email
            };

            // p/ comandos de manipulação (insert, delete, update), utiliza-se ExecuteAsync
            var alunoCadastrado = await _connection.ExecuteAsync(sql, parametros);

            return alunoCadastrado > 0;
        }


        public async Task<bool> AtualizarAlunoAsync(Aluno aluno)
        {
            try
            {
                string sql = @"
            UPDATE ALUNOS 
            SET Nome = @Nome, 
            Idade = @Idade, 
            Email = @Email 
            WHERE ALUNOID = @Id";

                var parametros = new
                {
                    Nome = aluno.Nome,
                    Idade = aluno.Idade,
                    Email = aluno.Email,
                    Id = aluno.AlunoID
                };

                var resultado = await _connection.ExecuteAsync(sql, parametros);
                return resultado > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<AlunoComCurso> BuscaAlunoPorIdAsync(int id)
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
            c.Nome AS NomeCurso
            FROM Alunos a
            INNER JOIN Matriculas m ON a.AlunoID = m.AlunoID
            INNER JOIN Cursos c ON m.CursoID = c.CursoID
            WHERE a.AlunoID = @Id";

                var cursosDoAluno = await _connection.QueryAsync<CursoInfo>(sql, new { Id = id });

                var aluno = await _connection.QueryFirstOrDefaultAsync<AlunoComCurso>("SELECT * FROM Alunos WHERE AlunoID = @Id", new { Id = id });

                if (aluno != null)
                {
                    aluno.Cursos = cursosDoAluno.ToList();
                }

                return aluno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RetornoPaginado<Aluno>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade)
        {
            try
            {
                var aluno = new Aluno();

                string sql = "SELECT * FROM ALUNOS ORDER BY ALUNOID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

                var parametros = new
                {
                    OFFSET = (pagina - 1) * quantidade,
                    QUANTIDADE = quantidade
                };

                var alunos = await _connection.QueryAsync<Aluno>(sql, parametros);

                var totalAlunos = "SELECT COUNT(*) FROM ALUNOS";

                var retornoTotalAlunos = await _connection.ExecuteScalarAsync<int>(totalAlunos);

                var retornoPaginado = new RetornoPaginado<Aluno>
                {
                    TotalRegistros = retornoTotalAlunos,
                    Pagina = pagina,
                    QtdPagina = quantidade,
                    Retorno = alunos.ToList()
                };

                return retornoPaginado;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> DeletarAlunoAsync(int id)
        {
            try
            {
                string sql = string.Format("DELETE FROM ALUNOS WHERE ALUNOID={0}", id);
                var alunoExcluida = await _connection.ExecuteAsync(sql);
                return alunoExcluida > 0;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<IEnumerable<AlunoComCurso>> RecuperaTodosAlunosAsync()
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
        c.Nome AS NomeCurso
        FROM Alunos a
        LEFT JOIN Matriculas m ON a.AlunoID = m.AlunoID
        LEFT JOIN Cursos c ON m.CursoID = c.CursoID";

                var alunos = new List<AlunoComCurso>();
                var resultado = await _connection.QueryAsync<AlunoComCurso, CursoInfo, AlunoComCurso>(
                    sql,
                    (aluno, curso) =>
                    {
                        var alunoExistente = alunos.FirstOrDefault(a => a.AlunoID == aluno.AlunoID);

                        if (alunoExistente == null)
                        {
                            aluno.Cursos = new List<CursoInfo>();
                            alunos.Add(alunoExistente = aluno);
                        }

                        if (curso != null)
                        {
                            alunoExistente.Cursos.Add(curso);
                        }

                        return alunoExistente;
                    },
                    splitOn: "CursoID"
                );

                return alunos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
