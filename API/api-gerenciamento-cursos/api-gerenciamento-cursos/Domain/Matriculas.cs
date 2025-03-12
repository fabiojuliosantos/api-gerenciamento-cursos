using System.ComponentModel.DataAnnotations;

namespace api_gerenciamento_cursos.Domain
{
    public class Matriculas
    {
        public int MatriculaId { get; set; }
        public int AlunoID { get; set; }
        public int CursoID { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
