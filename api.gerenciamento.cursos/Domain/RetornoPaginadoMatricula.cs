namespace api.gerenciamento.cursos.Domain
{
    public class RetornoPaginadoMatricula<Matricula>
    {
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int QtdPagina { get; set; }
        public List<Matricula> Matriculas { get; set; }
    }
}
