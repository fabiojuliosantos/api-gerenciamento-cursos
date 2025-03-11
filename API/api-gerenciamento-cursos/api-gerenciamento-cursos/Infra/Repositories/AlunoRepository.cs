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
            string sql = "INSERT INTO ALUNOS (Nome, Idade, Email, DataMatricula) VALUES (@Nome, @Idade, @Email, @DataMatricula)";

            var parametros = new
            {
                aluno.Nome,
                aluno.Idade,
                aluno.Email,
                aluno.DataMatricula
            };

            // p/ comandos de manipulação (insert, delete, update), utiliza-se ExecuteAsync
            var alunoCadastrado = await _connection.ExecuteAsync(sql, parametros);

            return alunoCadastrado > 0;
        }
        

        public async Task<bool> AtualizarAlunoAsync(Aluno aluno)
        {
            try
            {

                string sql = "UPDATE ALUNOS SET NOME = @Nome, IDADE = @Idade, EMAIL = @Email, DATAMATRICULA = @DataMatricula WHERE ID = @Id";


                var parametros = new
                {
                    aluno.Nome,
                    aluno.Idade,
                    aluno.Email,
                    aluno.DataMatricula,
                    aluno.AlunoID 
                };

                var resultado = await _connection.ExecuteAsync(sql, parametros);

                return resultado > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Aluno> BuscaAlunoPorIdAsync(int id)
        {
            try
            {
                string sql = $"SELECT * FROM Aluno WHERE AlunoID = {id}";
                var alunos = await _connection.QueryFirstOrDefaultAsync<Aluno>(sql);
                return alunos;
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

        public async Task<IEnumerable<Aluno>> RecuperaTodosAlunosAsync()
        {
            try { 
            string sql = "SELECT * FROM Aluno";
            var alunos = await _connection.QueryAsync<Aluno>(sql);
            return alunos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
