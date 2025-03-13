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
        private readonly IMapper _mapper;

        public MatriculaRepository(IDbConnection conn, IMapper mapper)
        {
            _conn = conn;
            _mapper = mapper;
        }

        public async Task<bool> MatricularAluno(Matricula matricula)
        {
            try
            {
                string sql = "INSERT INTO MATRICULAS (AlunoID, CursoID, DataMatricula) VALUES(@AlunoID, @CursoID, @DataMatricula)";

                var parametros = new
                {
                    AlunoID = matricula.AlunoId,
                    CursoID = matricula.CursoId,
                    DataMatricula = DateTime.Now
                };

                var matriculasAdicionadas = await _conn.ExecuteAsync(sql, parametros);

                return matriculasAdicionadas > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        

        public async Task<bool> RemoverMatricula(int id)
        {
            try
            {
                string sql = string.Format("DELETE FROM MATRICULAS WHERE ALUNOID={0}", id);
                var matriculaExcluida = await _conn.ExecuteAsync(sql);
                return matriculaExcluida > 0;
            }
            catch (Exception ex) { throw; }
        }
        

        public async Task<RetornoPaginadoAlunos<Matricula>> RetornoPaginadoMatricula(int pagina, int quantidade)
        {
            try
            {
                string sql = "SELECT * FROM MATRICULAS ORDER BY MATRICULAID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY ";

                var parametros = new
                {
                    OFFSET = (pagina - 1) * quantidade,

                    QUANTIDADE = quantidade
                };

                var matricula = await _conn.QueryAsync<Matricula>(sql, parametros);

                var totalMatricula = "SELECT COUNT(*) FROM MATRICULAS ";

                var retornoTotalMatricula = await _conn.ExecuteScalarAsync<int>(totalMatricula);

                return new RetornoPaginadoAlunos<Matricula>()
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
