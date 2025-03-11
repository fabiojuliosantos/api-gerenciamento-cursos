namespace gerenciamento_cursos_api.Domain.Entities;

public class Matricula
{
    public int MatriculaID { get; set; }
    public int AlunoID { get; set; }
    public int CursoID { get; set; }
    public DateTime DataMatricula { get; set; }
}
