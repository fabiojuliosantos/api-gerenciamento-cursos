namespace gerenciamento_cursos_api.Domain.Entities;

public class Curso
{
    public int CursoID { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int CargaHoraria { get; set; }
}
