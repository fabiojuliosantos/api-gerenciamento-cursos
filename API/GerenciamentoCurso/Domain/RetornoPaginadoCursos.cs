namespace GerenciamentoCurso.Domain
{
    public class RetornoPaginadoCursos
    {
        public class RetornoPaginado<Cursos>
        {
            public int TotalRegistro { get; set; }
            public int Pagina { get; set; }
            public int QtdPagina { get; set; }
            public List<Cursos>? Retorno { get; set; }
        }

    }
}
