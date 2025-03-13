namespace GerenciamentoCurso.Domain;

public class RetornoPaginadoAlunos<Alunos> 
{
    public int TotalRegistro { get; set; }
    public int Pagina { get; set; }
    public int QtdPagina { get; set; }
    public List<Alunos> ? Retorno { get; set; }
}
