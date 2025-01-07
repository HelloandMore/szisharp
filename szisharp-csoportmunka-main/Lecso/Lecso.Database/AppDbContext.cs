namespace Lecso.Database;

public class AppDbContext : DbContext
{
    public DbSet<TeamsEntity> Teams { get; set; }
    public DbSet<CompetitionEntity> Competition { get; set; }
    public DbSet<JudgeEntity> Judge { get; set; }
    public DbSet<LocationEntity> Location { get; set; }
    public DbSet<MemberEntity> Member { get; set; }

    public AppDbContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Lecso;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        //.LogTo(a => Console.WriteLine(a));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TeamsEntity>().HasData();
    }
}
