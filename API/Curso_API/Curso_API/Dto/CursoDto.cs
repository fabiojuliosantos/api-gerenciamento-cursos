using System.ComponentModel.DataAnnotations;

namespace Curso_API.Dto;

public class CursoDto
{
    [Required(ErrorMessage ="O nome do curso é um campo obrigatório!")]
    [MaxLength(100,ErrorMessage ="O nome no curso só pode possuir no máximo 100 caracteres")]
    public string Nome { get; set; }
    [MaxLength(500,ErrorMessage ="A descrição pode possuir no máximo 500 caracteres")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "A carga horária do curso é um campo obrigatório!")]
    [Range(1,int.MaxValue,ErrorMessage ="Carga horária inválida!")]
    public int CargaHoraria { get; set; }
}
