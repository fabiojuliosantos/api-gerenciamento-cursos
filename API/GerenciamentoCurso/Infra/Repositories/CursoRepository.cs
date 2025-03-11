using System.Data;
using AutoMapper;
using Dapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Infra.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GerenciamentoCurso.Infra.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IDbConnection _conn;
        private readonly IMapper _mapper;

        public CursoRepository(IDbConnection conn, IMapper mapper)
        {
            _conn = conn;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarCurso(Cursos cursos)
        {
            try
            {
                string sql = "UPDATE CURSOS SET NOME = @NOME, DESCRICAO = @DESCRICAO, CARGAHORARIA = @CARGAHORARIA WHERE CURSOID = @CURSOID";
                var parametros = new
                {
                    cursos.Nome,
                    cursos.Descricao,
                    cursos.CargaHoraria
                };

                var resultado = await _conn.ExecuteAsync(sql, parametros);

                return resultado > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> CriarCurso(Cursos cursos)
        {
            try
            {
                string sql = "INSERT INTO CURSOS(NOME,DESCRICAO,CARGAHORARIA) values (@NOME,@DESCRICAO,@CARGAHORARIA)";
                var parametros = new
                {
                    cursos.Nome,
                    cursos.Descricao,
                    cursos.CargaHoraria

                };

                var resultado = await _conn.ExecuteAsync(sql, parametros);

                return resultado > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeletarCurso(int id)
        {
            try
            {
                string sql = $"DELETE FROM CURSOS WHERE CURSOID = {id}";
                var resultado = await _conn.ExecuteAsync(sql);

                return resultado > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task<IEnumerable<Cursos>> ExibirCursos()
        {
            try
            {
                string sql = "SELECT * FROM CURSOS";
                var resultado = await _conn.QueryFirstOrDefault(sql);
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cursos> RetornoCursoId(int id)
        {
            try
            {

                string sql = $"select * from CURSOS WHERE CURSOID = {id}";
                var resultado = await _conn.QueryFirstOrDefault(sql);


                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RetornoPaginado<Cursos>> RetornoPaginadoCurso(int pagina, int quantidade)
        {
            try
            {
                string sql = "SELECT * FROM CURSOS ORDER BY CURSOID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY ";

                var parametros = new
                {
                    OFFSET = (pagina - 1) * quantidade,

                    QUANTIDADE = quantidade
                };

                var cursos = await _conn.QueryAsync<Cursos>(sql, parametros);

                var totalCursos = "SELECT COUNT(*) FROM ALUNOS ";

                var retornoTotalCursos = await _conn.ExecuteScalarAsync<int>(totalCursos);

                return new RetornoPaginado<Cursos>()
                {
                    Pagina = pagina,
                    QtdPagina = quantidade,
                    TotalRegistro = retornoTotalCursos,
                    Retorno = cursos.ToList()

                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
