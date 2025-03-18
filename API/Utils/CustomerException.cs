namespace Api.Utils;

//Boa tratativa de erros, moldando o retorno do erro de acordo com o que for passado pela aplicação
public class CustomerException : Exception
{
    public int ErrorCode { get; private set; }

    public CustomerException() { }

    public CustomerException(string message) : base(message) { }

    public CustomerException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

}