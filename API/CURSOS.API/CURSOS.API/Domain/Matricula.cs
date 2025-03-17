namespace CURSOS.API.Domain;

public class Matricula
{
    public int MatriculaID { get; set; }
    public int AlunoId { get; set; }
    public int CursoId { get; set; }
    public DateTime DataMatricula { get; set; }
}
