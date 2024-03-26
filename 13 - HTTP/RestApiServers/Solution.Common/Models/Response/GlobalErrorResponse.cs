namespace Solution.Common.Models.Response;

public class GlobalErrorResponse
{
    public static bool IsDevelopment { get; private set; }

    public string Type { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }

    public static void Configure(bool isDevelopment)
    {
        IsDevelopment = isDevelopment;
    }

    public GlobalErrorResponse(Exception? ex)
    {
        Type = ex?.GetType().Name ?? string.Empty;
        Message = GetMessages(ex) ?? string.Empty;
        StackTrace = IsDevelopment && ex is not null ? ex.ToString() : "Internal server error";
    }

    private string GetMessages(Exception? ex)
    {
        if (ex is null)
            return "";

        if (ex.InnerException is null)
            return ex.Message;

        return $"{ex.Message} {GetMessages(ex.InnerException)}";
    }
}
