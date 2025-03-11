using System.Data;
using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Infra.Interfaces;
using AutoMapper;
using Dapper;

namespace api_gerenciamento_cursos.Infra.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly IDbConnection _connection;
        private readonly IMapper _mapper;
        public MatriculaRepository(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }
        public Task<bool> AdicionarMatriculaAsync(Matriculas matriculas)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarMatriculaAsync(Matriculas matriculas)
        {
            throw new NotImplementedException();
        }

        public async Task<RetornoPaginado<Matriculas>> ListarMatriculasPaginadoAsync(int pagina, int quantidade)
        {
            try
            {
                string sql = "SELECT * FROM MATRICULAS ORDER BY MATRICULAID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

                var parametros = new
                {
                    OFFSET = (pagina - 1) * quantidade,
                    QUANTIDADE = quantidade

                };

                var matriculas = await _connection.QueryAsync<Matriculas>(sql, parametros);

                var totalMatriculas = "SELECT COUNT(*) FROM MATRICULAS";

                var retornoTotalMatriculas = await _connection.ExecuteScalarAsync<int>(totalMatriculas);

                var retornoPaginado = new RetornoPaginado<Matriculas>
                {
                    TotalRegistros = retornoTotalMatriculas,
                    Pagina = pagina,
                    QtdPagina = quantidade,
                    Retorno = matriculas.ToList()
                };

                return retornoPaginado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
