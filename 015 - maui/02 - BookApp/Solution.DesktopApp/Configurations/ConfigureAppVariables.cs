namespace Solution.DesktopApp.Configurations;

public static class ConfigureAppVariables
{
	public static MauiAppBuilder UseAppConfigurations(this MauiAppBuilder builder)
	{
#if DEBUG
        var file = "Resources.Raw.appSettings.Development.json";
#else
        var file = "Resources.Raw.appSettings.Production.json";
#endif


        var assembly = typeof(App).GetTypeInfo().Assembly;
		var assemblyName = assembly.GetName().Name.Replace(" ", "_");

		var stream = assembly.GetManifestResourceStream($"{assemblyName}.{file}");

		var config = new ConfigurationBuilder()
					.AddJsonStream(stream)
					.Build();

		builder.Configuration.AddConfiguration(config);

		return builder;
	}
}
