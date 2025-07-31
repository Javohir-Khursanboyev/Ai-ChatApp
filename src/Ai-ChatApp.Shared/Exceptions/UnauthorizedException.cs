namespace Ai_ChatApp.Shared.Exceptions;

public sealed class UnauthorizedException : Exception
{
    public UnauthorizedException() { }

    public UnauthorizedException(string message)
        : base(message) { }

    public UnauthorizedException(string message, Exception exception)
        : base(message, exception) { }

    public int StatusCode => 401;
}
