namespace Solution.Common.Models.Exceptions;

public sealed class ValidationFailureException : Exception, IApiException
{
    public HttpStatusCode Status => HttpStatusCode.BadRequest;

    public IDictionary<string, string[]> Failures { get; }

    public ValidationFailureException(string message = "") : base(message)
    {
        Failures = new Dictionary<string, string[]>();
    }

    public ValidationFailureException(ModelStateDictionary modelStateDictionary) : base("One or more validation failures have occurred.")
    {
        Failures = modelStateDictionary.Where(p => p.Value?.Errors.Any() ?? false)
                                       .ToDictionary(k => k.Key, v => v.Value!.Errors.Select(e => e.ErrorMessage)
                                       .ToArray());
    }
}
