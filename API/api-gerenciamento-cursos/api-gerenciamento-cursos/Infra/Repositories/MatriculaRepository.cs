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
        public async Task<bool> AdicionarMatriculaAsync(Matriculas matriculas)
        {
            try
            {
                string sql = "INSERT INTO MATRICULAS (AlunoID, CursoID, DataMatricula) VALUES(@AlunoID, @CursoID, @DataMatricula)";

                var parametros = new
                {
                    AlunoID = matriculas.AlunoID,
                    CursoID = matriculas.CursoID,
                    DataMatricula = matriculas.DataMatricula
                };

                var matriculasAdicionadas = await _connection.ExecuteAsync(sql, parametros);

                return matriculasAdicionadas > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeletarMatriculaAsync(int id)
        {
            try
            {
                string sql = string.Format("DELETE FROM MATRICULAS WHERE ALUNOID={0}", id);
                var matriculaExcluida = await _connection.ExecuteAsync(sql);
                return matriculaExcluida > 0;
            }
            catch (Exception ex) { throw; }
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
