namespace GerenciamentoCurso.Domain
{
    public class RetornoPaginadoCursos
    {
        /*
            Como já foi criada a classe de RetornoPaginado utilizando parâmetros genéricos, não precisaria criar essa classe aqui
        */
        public class RetornoPaginado<Cursos>
        {
            public int TotalRegistro { get; set; }
            public int Pagina { get; set; }
            public int QtdPagina { get; set; }
            public List<Cursos>? Retorno { get; set; }
        }

    }
}
