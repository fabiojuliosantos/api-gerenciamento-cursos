using Api.Domain;

namespace Api.Infra.Interfaces;

public interface ICursoRepository
{
    Task<List<Curso>> ListaTodosCursos();
    Task<Curso> ListaCursoPorId(int id);
    Task<List<Curso>> ListaCursoPorAlunoId(int alunoId);
    Task<bool> CriaCurso(Curso curso);
    Task<bool> AtualizaCurso(Curso curso);
    Task<bool> DeletaAluno(int id);
}