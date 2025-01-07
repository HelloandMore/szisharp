namespace Tancverseny.Database;

public class AppDbContext : DbContext
{
    public DbSet<CompetitionEntity> Competition { get; set; }
    public DbSet<GroupEntity> Group { get; set; }
    public DbSet<LocationEntity> Location { get; set; }
    public DbSet<CityEntity> City { get; set; }
    public DbSet<CountryEntity> Country { get; set; }
    public DbSet<ParticipantEntity> Participants { get; set; }

    public AppDbContext(): base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TancVerseny;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        //.LogTo(a => Console.WriteLine(a));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<TeamsEntity>().HasData();
    }
}
