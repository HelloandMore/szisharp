namespace Solution.Configurations.WebApplicationBuilderExtensions;

public static class SerilogConfiguration
{
    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        if (builder is null)
            return;

        var template = new ExpressionTemplate(template: "{@l:w4} : {@m}\n", theme: TemplateTheme.Code);

        var rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var logPath = $@"{rootDir}\logs\log-.txt";

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Async(x => x.Logger((configureLogger) =>
            {
                configureLogger.Filter.ByExcluding("@m like '%Service Profiler%' ci");
                configureLogger.Filter.ByExcluding("@m like '%Finished calling trace uploader%' ci");
                configureLogger.Filter.ByExcluding("@m like '%Uploader to be used%' ci");
                configureLogger.Filter.ByExcluding("@m like '%BasicAuthentication was not authenticated%' ci");
                configureLogger.Filter.ByExcluding("@m like '%Microsoft.ApplicationInsights.Profiler.Core%' ci");

                configureLogger.WriteTo.Async(consoleConfiguration => consoleConfiguration.Console(template));
                configureLogger.WriteTo.Async(fileConfiguration => fileConfiguration.File(logPath, rollingInterval: RollingInterval.Day, fileSizeLimitBytes: null));
            }))
            .Enrich.FromLogContext()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Error)
            .CreateBootstrapLogger();

        builder.Host.UseSerilog();
    }
}
