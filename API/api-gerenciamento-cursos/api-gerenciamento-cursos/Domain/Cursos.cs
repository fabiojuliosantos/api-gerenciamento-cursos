using System.ComponentModel.DataAnnotations;

namespace api_gerenciamento_cursos.Domain
{
    public class Cursos
    {
        public int CursoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
    }
}
