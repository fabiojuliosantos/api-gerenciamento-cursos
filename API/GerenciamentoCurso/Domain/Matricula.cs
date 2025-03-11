namespace GerenciamentoCurso.Domain;

public class Matricula
{
    public int MatriculaId { get; set; }
    public int AlunoId { get; set; }
    public int CursoId { get; set; }
    public DateTime DataMatricula { get; set; }
}
