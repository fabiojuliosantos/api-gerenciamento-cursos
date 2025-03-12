using System.Text.Json.Serialization;

namespace api.gerenciamento.cursos.Domain
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }  
        public DateTime DataMatricula { get; set; }
        [JsonIgnore]
        public int MatriculaID { get; set; }
        public List<Curso> Cursos { get; set; } 

    }
}
