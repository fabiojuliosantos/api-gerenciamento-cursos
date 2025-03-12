using System.ComponentModel.DataAnnotations;

namespace api_gerenciamento_cursos.Domain
{
    public class Matriculas
    {
        public int MatriculaId { get; set; }
        [Required(ErrorMessage = "Informe o ID do aluno")]
        public int AlunoID { get; set; }
        [Required(ErrorMessage = "Informe o ID do curso")]
        public int CursoID { get; set; }
        [Required(ErrorMessage = "Informe a data da matricula")]
        public DateTime DataMatricula { get; set; }
    }
}
