using Solution.Common.Models.Constants;

namespace Solution.Configurations.WebApplicationBuilderExtensions;

public static class CorsConfiguration
{
    public static void ConfigureCORS(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(Constants.CorsPolicy, policy =>
            {
                policy.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Value!.Split(","))
                      .WithHeaders(builder.Configuration.GetSection("AllowedHeaders").Value!.Split(","))
                      .WithMethods(builder.Configuration.GetSection("AllowedMethods").Value!.Split(","));
            });
        });
    }

    public static void ConfigureCORS(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseCors(Constants.CorsPolicy);
    }
}
