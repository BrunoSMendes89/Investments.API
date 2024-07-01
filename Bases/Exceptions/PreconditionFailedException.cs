using System.Net;

public class PreconditionFailedException : Exception
{
    public PreconditionFailedException(string message = "Precondition Failed", Exception exception = default) : base(message, exception)
    {
    }
}
