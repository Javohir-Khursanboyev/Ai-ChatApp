namespace Ai_ChatApp.Shared.Exceptions;

public sealed class InternalServerException : Exception
{
    public InternalServerException() { }

    public InternalServerException(string message)
        : base(message) { }

    public InternalServerException(string message, Exception exception)
        : base(message, exception) { }

    public int StatusCode => 500;
}
