namespace Solution.DataBase;

public class AppDbContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }

    private static string connectionString = string.Empty;

    static AppDbContext()
    {
        connectionString = "Data Source=localhost;Database=BookDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ArgumentNullException.ThrowIfNull(connectionString);

        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(connectionString);
    }

    private static string GetConnectionString()
    {
#if DEBUG
        var file = "connectionString.Development.json";
#else
        var file = "connectionString.Development.json";
#endif
		var stream = new MemoryStream(File.ReadAllBytes($"{file}"));

        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

        var connectionStirng = config.GetValue<string>("SqlConnectionString");

        return connectionStirng;
    }
}
