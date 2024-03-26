namespace Solution.Configurations.Middlewares;

public class ApiExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;
    private readonly IWebHostEnvironment environment;
    private readonly ILogger<ApiExceptionHandlerMiddleware> logger;

    public ApiExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment environment, ILogger<ApiExceptionHandlerMiddleware> logger)
    {
        this.next = next;
        this.environment = environment;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ExceptionDispatchInfo? exceptionInfo;

        try
        {
            await next(context);
            return;
        }
        catch (Exception e)
        {
            exceptionInfo = ExceptionDispatchInfo.Capture(e);
        }

        await HandleException(context, exceptionInfo);
    }

    private async Task HandleException(HttpContext context, ExceptionDispatchInfo exceptionDispatchInfo)
    {
        var exception = exceptionDispatchInfo.SourceException;

        if (exception is not IApiException)
            logger.LogError(exception.ToString());
        else
            logger.LogWarning(exception.ToString());

        if (exception is ValidationFailureException validationException)
            await WriteValidationProblemDetails(context, validationException);
        else
            await WriteProblemDetails(context, exception);
    }

    private async Task WriteProblemDetails(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = exception is IApiException apiException ?
                                      (int)apiException.Status :
                                      (int)HttpStatusCode.InternalServerError;

        var problemDetails = new ProblemDetails
        {
            Status = context.Response.StatusCode,
        };

        PopulateProblemDetails(problemDetails, context, exception);

        await context.Response.WriteAsJsonAsync(problemDetails);
    }

    private async Task WriteValidationProblemDetails(HttpContext context, ValidationFailureException exception)
    {
        context.Response.StatusCode = (int)exception.Status;

        var problemDetails = new ValidationProblemDetails(exception.Failures)
        {
            Status = context.Response.StatusCode,
        };

        PopulateProblemDetails(problemDetails, context, exception);

        await context.Response.WriteAsJsonAsync(problemDetails);
    }

    private void PopulateProblemDetails(ProblemDetails problemDetails, HttpContext context, Exception exception)
    {
        problemDetails.Type = exception.GetType().GetNameWithoutGenericArity();
        problemDetails.Detail = !string.IsNullOrEmpty(exception.Message) ?
                                exception.Message :
                                "Unexpected error has occurred.";
        
        problemDetails.Extensions["traceId"] = Activity.Current?.Id ?? context.TraceIdentifier;

        if (environment.IsDevelopment())
            problemDetails.Extensions["exception"] = exception.ToString();
    }
}
