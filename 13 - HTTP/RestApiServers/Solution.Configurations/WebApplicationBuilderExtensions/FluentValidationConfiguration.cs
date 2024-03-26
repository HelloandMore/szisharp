namespace Solution.Configurations.WebApplicationBuilderExtensions;

public static class FluentValidationConfiguration
{
    public static void ConfigureFluentValidation(this WebApplicationBuilder builder)
    {
        //disable built in model validator
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        builder.Services.AddFluentValidationAutoValidation();
        builder.RegisterFluentValidators();
    }
}
