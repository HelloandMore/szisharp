namespace OOT.Database.Entities;

[Table("Classification")]

public class ClassificationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public virtual IReadOnlyCollection<SpeciesEntity> Species { get; set; }

    public virtual IReadOnlyCollection<BirdEntity> Birds { get; set; }
}
