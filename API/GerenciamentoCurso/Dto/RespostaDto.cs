namespace GerenciamentoCurso.Dto
{
    public class RespostaDto
    {
        public RespostaDto(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
