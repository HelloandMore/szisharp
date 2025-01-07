namespace AtletikaBajnoksag.Database;

public class AppDbContext : DbContext
{
    public DbSet<LocationEntity> Location { get; set; }
    public DbSet<CompetitionEntity> Competition { get; set; }
    public DbSet<CompetitionNumberEntity> CompetitionNumber { get; set; }
    public DbSet<CityEntity> City { get; set; }
    public DbSet<SupervisorEntity> Supervisor { get; set; }
    public DbSet<CompetitorEntity> Competitor { get; set; }
    public DbSet<OrganizationEntity> Organization { get; set; }

public AppDbContext() : base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AtletikaBajnoksag;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CompetitorEntity>().HasOne(x => x.Location).WithMany(x => x.Competitors).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<CompetitorEntity>().HasOne(x => x.Organization).WithMany(x => x.Competitors).OnDelete(DeleteBehavior.NoAction);
        // modelBuilder.Entity<MemberEntity>().HasMany(x => x.RingedBirds).WithOne(x => x.Ringer).OnDelete(DeleteBehavior.NoAction);
        // modelBuilder.Entity<WatchingEntity>().HasOne(x => x.Bird).WithMany(x => x.Watchings).OnDelete(DeleteBehavior.NoAction);
    }
}
