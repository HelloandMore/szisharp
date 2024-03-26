namespace Solution.Configurations.WebApplicationBuilderExtensions;

public static class SwaggerConfiguration
{
    private const string API_VERSION = "v1";

    public static void ConfigureSwagger(this WebApplicationBuilder builder)
    {
        string path = "version.txt";
        string version = $"{path} does not exists";

        if (File.Exists(path))
            version = File.ReadAllText(path);

        builder.Services.AddSwaggerGen(x =>
        {
            x.EnableAnnotations();
            x.UseInlineDefinitionsForEnums();
            x.SwaggerDoc(API_VERSION, new() { Title = $"Excersise API - {version}", Version = version, Description = "Excersise API endpoints" });
            
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
            });

            x.AddSecurityDefinition("Basic", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Basic",
                Description = "Input your user name and password to access this API",
                In = ParameterLocation.Header
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                      new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic"
                            }
                        },
                        new string[] {}
                }
            });
        });
    }

    public static void ConfigureSwagger(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseSwagger();

        applicationBuilder.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/{API_VERSION}/swagger.json", "Excersise API");
            options.DocExpansion(DocExpansion.None);
        });
    }
}
