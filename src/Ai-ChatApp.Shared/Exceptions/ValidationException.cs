namespace Ai_ChatApp.Shared.Exceptions;

public sealed class ValidationException : Exception
{
    public ValidationException() { }

    public ValidationException(string message)
        : base(message) { }

    public ValidationException(string message, Exception exception)
        : base(message, exception) { }

    public int StatusCode => 400;
}
