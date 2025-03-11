namespace GerenciamentoCurso.Domain;

public class RetornoPaginado<T> where T : class
{
    public int TotalRegistro { get; set; }
    public int Pagina { get; set; }
    public int QtdPagina { get; set; }
    public List<T> Retorno { get; set; }
}
