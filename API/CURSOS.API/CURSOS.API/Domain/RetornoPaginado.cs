namespace CURSOS.API.Domain;

public class RetornoPaginado<T>
{
    public int TotalRegistros { get; set; }
    public int Pagina { get; set; }
    public int QtdaPagina { get; set; }
    public List<T> Itens { get; set; }
}
