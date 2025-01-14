namespace Solution.DesktopApp.Configurations;

public static class ConfigureFonts
{
	public static MauiAppBuilder UseFontConfiguration(this MauiAppBuilder builder)
	{
		builder.ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
		});

		return builder;
	}
}
