namespace gerenciamento_cursos_api.Domain.Entities;

public class RetornoPaginado<T> 
    where T : class
{
    public int TotalRegistros { get; set; }
    public int Pagina { get; set; }
    public int QtdPagina { get; set; }
    public List<T> Registros { get; set; }
    public string Mensagem { get; set; }
}