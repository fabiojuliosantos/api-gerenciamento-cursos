namespace GerenciamentoCurso.Domain
{
    public class RetornoPaginadoMatricula
    {
        public class RetornoPaginado<Matricula>
        {
            public int TotalRegistro { get; set; }
            public int Pagina { get; set; }
            public int QtdPagina { get; set; }
            public List<Matricula>? Retorno { get; set; }
        }

    }
}
