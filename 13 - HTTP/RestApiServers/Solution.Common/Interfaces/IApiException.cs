namespace Solution.Common.Interfaces;

public interface IApiException
{
    HttpStatusCode Status { get; }
}
