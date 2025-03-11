using System.Data;
using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Infra.Interfaces;
using Dapper;

namespace api_gerenciamento_cursos.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDbConnection _connection;

        public AlunoRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public Task<bool> AdicionaAlunoAsync(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarAlunoAsync(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> BuscaAlunoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RetornoPaginado<Aluno>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAlunoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Aluno>> RecuperaTodosAlunosAsync()
        {
            try { 
            string sql = "SELECT * FROM Aluno";
            var alunos = await _connection.QueryAsync<Aluno>(sql);
            return alunos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
