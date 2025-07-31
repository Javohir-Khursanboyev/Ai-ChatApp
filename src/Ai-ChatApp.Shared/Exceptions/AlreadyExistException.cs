namespace Ai_ChatApp.Shared.Exceptions;

public sealed class AlreadyExistException : Exception
{
    public AlreadyExistException() { }

    public AlreadyExistException(string message)
        : base(message) { }

    public AlreadyExistException(string message, Exception exception)
        : base(message, exception) { }

    public int StatusCode => 409;
}