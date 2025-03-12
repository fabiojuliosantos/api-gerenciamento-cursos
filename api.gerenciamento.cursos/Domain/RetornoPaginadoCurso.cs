namespace api.gerenciamento.cursos.Domain
{
    public class RetornoPaginadoCurso<Curso>
    {
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int QtdPagina { get; set; }
        public List<Curso> Cursos { get; set; }

    }
}
