using System.ComponentModel.DataAnnotations;

namespace Curso_API.Dto;

public class CursoDto
{

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int CargaHoraria { get; set; }
}
