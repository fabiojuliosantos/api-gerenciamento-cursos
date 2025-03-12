using System.ComponentModel.DataAnnotations;

namespace api_gerenciamento_cursos.Dto
{
    public class MatriculaDto
    {
        [Required(ErrorMessage = "Informe o ID do aluno")]
        public int AlunoID { get; set; }
        [Required(ErrorMessage = "Informe o ID do curso")]
        public int CursoID { get; set; }
        [Required(ErrorMessage = "Informe a data da matricula")]
        public DateTime DataMatricula { get; set; }
    }
}
