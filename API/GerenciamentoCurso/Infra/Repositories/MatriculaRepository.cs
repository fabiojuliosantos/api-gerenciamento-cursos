using System.Data;
using AutoMapper;
using Dapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Infra.Interface;

namespace GerenciamentoCurso.Infra.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly IDbConnection _conn;
        private readonly Mapper _mapper;

        public MatriculaRepository(IDbConnection conn, Mapper mapper)
        {
            _conn = conn;
            _mapper = mapper;
        }

        public Task<bool> MatricularAluno(Matricula matricula)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverMatricula(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RetornoPaginado<Matricula>> RetornoPaginadoMatricula(int pagina, int quantidade)
        {
            try
            {
                string sql = "SELECT * FROM MATRICULA ORDER BY MATRICULAID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY ";

                var parametros = new
                {
                    OFFSET = (pagina - 1) * quantidade,

                    QUANTIDADE = quantidade
                };

                var matricula = await _conn.QueryAsync<Matricula>(sql, parametros);

                var totalMatricula = "SELECT COUNT(*) FROM MATRICULAS ";

                var retornoTotalMatricula = await _conn.ExecuteScalarAsync<int>(totalMatricula);

                return new RetornoPaginado<Matricula>()
                {
                    Pagina = pagina,
                    QtdPagina = quantidade,
                    TotalRegistro = retornoTotalMatricula,
                    Retorno = matricula.ToList()

                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
