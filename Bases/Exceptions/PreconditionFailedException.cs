using System.Net;

public class PreconditionFailedException : Exception
{
    public PreconditionFailedException(string message = "Precondition Failed", HttpStatusCode httpStatusCode = HttpStatusCode.PreconditionFailed) : base(message)
    {
    }
}
