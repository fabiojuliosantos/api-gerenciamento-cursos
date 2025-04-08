namespace gerenciamentoCursos.Domain;

public class Aluno
{
    public int AlunoID { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
    public DateTime DataMatricula { get; set; }
    public List<Curso> Curso { get; set; }
}
