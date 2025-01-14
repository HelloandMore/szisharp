namespace Solution.DesktopApp.Configurations;

public static class ConfigureSQLServer
{
	public static MauiAppBuilder UseMsSqlServer(this MauiAppBuilder builder)
	{	
		builder.Services.AddDbContext<AppDbContext>();

		return builder;
	}
}
