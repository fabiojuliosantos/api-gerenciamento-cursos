using System.Data;
using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Infra.Interfaces;
using AutoMapper;
using Dapper;

namespace api_gerenciamento_cursos.Infra.Repositories
{
    public class CursosRepository : ICursosRepository
    {
        private readonly IDbConnection _connection;
        private readonly IMapper _mapper;

        public CursosRepository(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }
        public async Task<bool> AdicionaCursosAsync(Cursos cursos)
        {
            try
            {
                string sql = "INSERT INTO CURSOS (Nome, Descricao, CargaHoraria) VALUES(@Nome, @Descricao, @CargaHoraria)";

                var parametros = new
                {
                    cursos.Nome,
                    cursos.Descricao,
                    cursos.CargaHoraria
                };

                var cursosAdicionados = await _connection.ExecuteAsync(sql, parametros);

                return cursosAdicionados > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> AtualizarCursosAsync(Cursos cursos)
        {
            try
            {
                string sql = "UPDATE CURSOS SET NOME = @Nome, DESCRICAO = @Descricao, CARGAHORARIA = @CargaHoraria WHERE CURSOID = @CursoID";

                var parametros = new
                {
                    cursos.Nome,
                    cursos.Descricao,
                    cursos.CargaHoraria,
                    cursos.CursoID
                };
                var cursosAtualizados = await _connection.ExecuteAsync(sql, parametros);
                return cursosAtualizados > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeletaCursosAsync(int id)
        {
            try
            {
                string sql = string.Format("DELETE FROM CURSOS WHERE CURSOID={0}", id);
                var cursoExcluido = await _connection.ExecuteAsync(sql);
                return cursoExcluido > 0;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<IEnumerable<Cursos>> RecuperaCursosAsync()
        {
            try
            {
                string sql = "SELECT * FROM CURSOS";
                var cursos = await _connection.QueryAsync<Cursos>(sql);
                return cursos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cursos> RecuperaCursosPorIdAsync(int id)
        {
            try
            {
                string sql = $"SELECT * FROM CURSOS WHERE CURSOID={id}";
                var cursos = await _connection.QueryFirstOrDefaultAsync<Cursos>(sql);
                return cursos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
