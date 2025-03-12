namespace api.gerenciamento.cursos.Domain
{
    public class RetornoPaginadoAluno<Aluno>
    {
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int QtdPagina { get; set; }
        public List<Aluno> Alunos { get; set; }

    }
}
