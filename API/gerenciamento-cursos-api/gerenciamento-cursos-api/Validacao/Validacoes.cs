using gerenciamento_cursos_api.Infra.Interfaces;
using gerenciamento_cursos_api.Infra.Repositories;

namespace gerenciamento_cursos_api.Validacao;

public class Validacoes
{
    private readonly IAlunoRepository _alunorepository;
    private readonly ICursoRepository _cursoRepository;
    private readonly IMatriculaRepository _matriculaRepository;

    public Validacoes(IAlunoRepository repository)
    {
        _alunorepository = repository;
    }

    public Validacoes(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public Validacoes(IMatriculaRepository matriculaRepository)
    {
        _matriculaRepository = matriculaRepository;
    }

    public bool ValidaEmail(string email)
    {
        var trimmedEmail = email.Trim(); // remove espaços do inicio e do fim

        if (trimmedEmail.EndsWith(".")) // Verifica se a string termina com .
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email); //Utilização de classe da biblioteca base do .NET
            return addr.Address == trimmedEmail; //retornando true caso o retorno do objeto MailAdress seja igual ao email inserido
        }
        catch
        {
            return false;
        }
    }

    public bool VerificaPaginaVazia(int pagina, int quantidade, int totalColaboradores)
    {
        int totalPaginas = totalColaboradores / quantidade;

        if (pagina > totalPaginas)
            return true; // Falso para quando a pagina solicitada for maior que o total de paginas (retornaria uma pagina vazia)
        else
            return false; // Verdadeiro para quando a pagina solicitada estiver dentro do total de paginas
    }
}
