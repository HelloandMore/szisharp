namespace Solution.DesktopApp.Configurations;

public static class ConfigurationOfAppSettingsMapping
{
    public static MauiAppBuilder UseAppSettingsMapping(this MauiAppBuilder builder)
    {
        //var appSettings = builder.Configuration.GetRequiredSection("AppSettings").Get<AppSettings>();
        //builder.Services.AddSingleton<AppSettings>(appSettings);

        return builder;
    }
}