namespace Solution.Configurations.WebApplicationBuilderExtensions;

public static class EnviorementVariablesConfiguration
{
    public static void ConfigureEnviorementVariables(this WebApplicationBuilder builder)
    {
        var environment = builder.Configuration.GetValue<string>("Environment");

        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", true)
                             .AddJsonFile($"appsettings.{environment}.json", true)
                             .AddEnvironmentVariables();
    }
}
