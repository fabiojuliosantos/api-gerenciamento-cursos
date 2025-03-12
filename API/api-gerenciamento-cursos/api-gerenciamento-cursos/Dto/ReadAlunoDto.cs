namespace api_gerenciamento_cursos.Dto
{
    public class ReadAlunoDto
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
