using System.ComponentModel.DataAnnotations;

namespace GerenciamentoCurso.Dto
{
    public class MatriculaDto
    {
        [Required(ErrorMessage = "Informe o ID do aluno")]
        public int AlunoID { get; set; }
        [Required(ErrorMessage = "Informe o ID do curso")]
        public int CursoID { get; set; }
        
        
    }
}
