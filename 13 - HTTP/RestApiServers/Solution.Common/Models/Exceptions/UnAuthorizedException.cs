namespace Solution.Common.Models.Exceptions;

public class UnAuthorizedException : Exception
{
    public UnAuthorizedException() : base(nameof(UnAuthorizedException)) { }

    public UnAuthorizedException(string? message) : base(message) { }

    public UnAuthorizedException(string? message, Exception? innerException) : base(message, innerException) { }
}
