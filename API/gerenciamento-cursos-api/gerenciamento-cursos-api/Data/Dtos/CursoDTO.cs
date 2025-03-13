namespace gerenciamento_cursos_api.Data.Dtos;

public class CursoDTO
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int CargaHoraria { get; set; }
}

public class UpdateCursoDTO
{
    public int CursoId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int CargaHoraria { get; set; }
}
