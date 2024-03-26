namespace Solution.Configurations.WebApplicationBuilderExtensions;

public static class DependencyInjectionConfiguration
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        // Add useful interface for accessing the ActionContext outside a controller.
        builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

        builder.Services.AddTransient<IValidatorInterceptor, FluentvalidationInterceptor>();
        builder.Services.AddSingleton<IAmazonsOfVolleyballService<Player, int>, AmazonsOfVolleyballService>();
        builder.Services.AddSingleton<IDigimonServiceService<Digimon, int>, DigimonServiceService>();
        builder.Services.AddSingleton<IBeerService<Beer, int>, BeerService>();
        builder.Services.AddSingleton<IGameService<Game, int>, GameServiceService>();
        builder.Services.AddSingleton<ILoLChampionService<Champion, int>, LoLChampionService>();
    }
}
