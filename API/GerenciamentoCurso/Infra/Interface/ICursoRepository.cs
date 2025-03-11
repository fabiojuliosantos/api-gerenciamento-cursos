using GerenciamentoCurso.Domain;

namespace GerenciamentoCurso.Infra.Interface;

public interface ICursoRepository
{
    Task<IEnumerable<Cursos>> ExibirCursos();
    Task<RetornoPaginado<Cursos>> RetornoPaginadoCurso(int pagina, int quantidade);
    Task<Cursos> RetornoCursoId(int id);
    Task<bool> CriarCurso(Cursos cursos);
    Task<bool> AtualizarCurso(Cursos cursos);
    Task<bool> DeletarCurso(int id);
}
