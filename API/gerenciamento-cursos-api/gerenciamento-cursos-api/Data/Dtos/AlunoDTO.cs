namespace gerenciamento_cursos_api.Data.Dtos;

public class AlunoDTO
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
}

public class UpdateAlunoDTO
{
    public int AlunoId { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
}