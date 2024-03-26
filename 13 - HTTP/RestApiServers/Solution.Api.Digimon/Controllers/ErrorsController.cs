namespace Solution.Api.Controllers;

[AllowAnonymous]
[ApiExplorerSettings(IgnoreApi = true)]
public partial class ErrorsController : ControllerBase
{
    [Logging]
    [Route("error")]
    public GlobalErrorResponse Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;

        Response.StatusCode = exception switch
        {
            BadHttpRequestException => 400,
            UnAuthorizedException => 401,
            InvalidCredentialException => 401,
            HttpStatusCodeException => ((HttpStatusCodeException)exception).StatusCode,
            _ => 500
        };

        return new GlobalErrorResponse(exception);
    }
}
