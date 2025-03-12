using GerenciamentoCurso.Domain;

namespace GerenciamentoCurso.Services.Interface
{
    public interface ICursoService
    {
        Task<IEnumerable<Cursos>> ExibirCursos();
        Task<RetornoPaginado<Cursos>> RetornoPaginadoCurso(int pagina, int quantidade);
        Task<Cursos> RetornoCursoId(int id);
        Task<bool> CriarCurso(Cursos cursos);
        Task<bool> AtualizarCurso(Cursos cursos);
        Task<bool> DeletarCurso(int id);
    }
}
