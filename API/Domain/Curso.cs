namespace Api.Domain;

public class Curso
{
    public int CursoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int CargaHoraria { get; set; }
}