namespace Api.Utils;

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