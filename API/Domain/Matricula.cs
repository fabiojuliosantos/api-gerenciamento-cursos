namespace Api.Domain;

public class Matricula
{
    public int MatriculaId { get; set; }
    public DateTime DataMatricula { get; set; }
    public int AlunoID { get; set; }
    public Aluno Aluno { get; set; }

    public int CursoID { get; set; }
    public Curso Curso { get; set; }
}