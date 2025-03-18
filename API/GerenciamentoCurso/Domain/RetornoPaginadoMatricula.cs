namespace GerenciamentoCurso.Domain
{
    public class RetornoPaginadoMatricula
    {
        /*
            O mesmo se aplica aqui, sobre a criação de classe para retorno Paginado.
        */
        public class RetornoPaginado<Matricula>
        {
            public int TotalRegistro { get; set; }
            public int Pagina { get; set; }
            public int QtdPagina { get; set; }
            public List<Matricula>? Retorno { get; set; }
        }

    }
}
