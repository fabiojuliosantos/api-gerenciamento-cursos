using System.Data;
using AutoMapper;
using Dapper;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Infra.Interface;

namespace GerenciamentoCurso.Infra.Repositories;

public class AlunosRepository : IAlunoRepository
{
    private readonly IDbConnection _conn;
    private readonly IMapper _mapper;

    public AlunosRepository(IDbConnection conn, IMapper mapper)
    {
        _conn = conn;
        _mapper = mapper;
    }

    public async Task<bool> AtualizarAlunoAsync(Alunos alunos)
    {
        try
        {
            string sql = @"UPDATE ALUNOS SET NOME = @NOME, EMAIL = @EMAIL, IDADE = @IDADE WHERE ALUNOID = @Id";
            var parametros = new
            {

                alunos.AlunoId,
                alunos.Nome,
                alunos.Email,
                alunos.Idade,
                Id = alunos.AlunoId

            };

            var resultado = await _conn.ExecuteAsync(sql, parametros);

            return resultado > 0;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> BuscarAlunoPorEmailAsync(string email)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM ALUNOS WHERE EMAIL={email}";
            var resultado = await _conn.QueryFirstOrDefault(sql);

            return resultado;
        }
        catch (Exception)
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

            var cursosDoAluno = await _conn.QueryAsync<InfoCurso>(sql, new { Id = id });

            var alunos = await _conn.QueryFirstOrDefaultAsync<AlunoComCurso>("SELECT * FROM ALUNOS WHERE ALUNOID = @Id", new { Id = id });

            if (alunos != null)
            {
                alunos.Cursos = cursosDoAluno.ToList();
            }

            return alunos;
        }
        catch (Exception)
        {
            throw;
        }
    }





    public async Task<bool> AdicionaAlunoAsync(Alunos alunos)
    {
        try
        {
            string sql = "insert into alunos(NOME,IDADE,EMAIL,DATAMATRICULA) values(@NOME,@IDADE,@EMAIL,@DATAMATRICULA)";

            var parametros = new
            {
                NOME = alunos.Nome,
                IDADE = alunos.Idade,
                EMAIL = alunos.Email,
                DATAMATRICULA = DateTime.Now
            };

            var resultado = await _conn.ExecuteAsync(sql, parametros);

            return resultado > 0;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> DeletarAlunoAsync(int id)
    {
        try
        {
            string sql = string.Format("DELETE FROM ALUNOS WHERE ALUNOID ={0}", id);
            var resultado = await _conn.ExecuteAsync(sql);

            return resultado > 0;
        }
        catch (Exception)
        {

            throw;
        }
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
            var resultado = await _conn.QueryAsync<AlunoComCurso, InfoCurso, AlunoComCurso>(
                sql,
                (aluno, curso) =>
                {
                    var alunoExistente = alunos.FirstOrDefault(a => a.AlunoID == aluno.AlunoID);

                    if (alunoExistente == null)
                    {
                        aluno.Cursos = new List<InfoCurso>();
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



    public async Task<RetornoPaginadoAlunos<Alunos>> BuscaAlunoPorPagina(int pagina, int quantidade)
    {
        try
        {
            string sql = @"SELECT * FROM ALUNOS 
                       ORDER BY ALUNOID 
                       OFFSET @OFFSET ROWS 
                       FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                QUANTIDADE = quantidade
            };

            var alunos = await _conn.QueryAsync<Alunos>(sql, parametros);

            
            foreach (var estudante in alunos)
            {
                string sql2 = @"SELECT c.* 
                            FROM matriculas M 
                            INNER JOIN cursos c ON M.CURSOID = C.CURSOID 
                            WHERE M.ALUNOID = @AlunoId"; 

                var parametrosCurso = new { AlunoId = estudante.AlunoId };
                var cursos = await _conn.QueryAsync<Cursos>(sql2, parametrosCurso);

                estudante.CursoMatriculado = cursos.ToList();
            }

            var totalAlunos = "SELECT COUNT(*) FROM ALUNOS";
            var retornoTotalAlunos = await _conn.ExecuteScalarAsync<int>(totalAlunos);

            var retornoPaginado = new RetornoPaginadoAlunos<Alunos>
            {
                TotalRegistro = retornoTotalAlunos,
                Pagina = pagina,
                QtdPagina = quantidade,
                Retorno = alunos.ToList()
            };

            return retornoPaginado;
        }
        catch (Exception ex) { throw; } // Considere tratar/logar a exceção
    }
}


