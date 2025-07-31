namespace Ai_ChatApp.Shared.Exceptions;

public sealed class ForbiddenException : Exception
{
    public ForbiddenException() { }

    public ForbiddenException(string message)
        : base(message) { }

    public ForbiddenException(string message, Exception exception)
        : base(message, exception) { }

    public int StatusCode => 403;
}
