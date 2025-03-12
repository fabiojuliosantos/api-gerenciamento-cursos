namespace api_gerenciamento_cursos.Domain
{
    public class AlunoComCurso
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public DateTime DataMatricula { get; set; }
        public List<CursoInfo> Cursos { get; set; }
    }

    public class CursoInfo
    {
        public int CursoID { get; set; }
        public string NomeCurso { get; set; }
    }
}
