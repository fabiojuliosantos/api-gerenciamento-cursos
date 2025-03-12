namespace GerenciamentoCurso.Domain
{
    public class AlunoComCurso
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public DateTime DataMatricula { get; set; }
        public List<InfoCurso> Cursos { get; set; }
    }

    public class InfoCurso
    {
        public int CursoID { get; set; }
        public string NomeCurso { get; set; }
    }
}
