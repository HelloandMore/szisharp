namespace OOT.Database;

public class AppDbContext : DbContext
{
    public DbSet<MemberEntity> Member {get; set;}
    public DbSet<BirdEntity> Bird {get; set;}
    public DbSet<ClassificationEntity> Classification {get; set;}
    public DbSet<LocationEntity> Location {get; set;}
    public DbSet<WatchingEntity> Watching {get; set;}
    public DbSet<TribeEntity> Tribe {get; set;}
    public DbSet<SubclassEntity> Subclass {get; set;}
    public DbSet<ClassEntity> Class {get; set;}
    public DbSet<SpeciesEntity> Species {get; set;}

    public AppDbContext() : base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OrszagosOrnitologiaiTarsasag;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MemberEntity>().HasMany(x => x.RingedBirds).WithOne(x => x.Ringer).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<WatchingEntity>().HasOne( x => x.Bird).WithMany(x => x.Watchings).OnDelete(DeleteBehavior.NoAction);
    }
}
