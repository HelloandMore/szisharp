namespace OOT.Database.Entities;

[Table("Species")]

public class SpeciesEntity
{
    [Key]
    public uint Id { get; set; }

    [Required]
    public string ClassName { get; set; }

    [ForeignKey("Classification")]
    public uint ClassificationId { get; set; }
    public virtual ClassificationEntity Classification { get; set; }

    public virtual IReadOnlyCollection<ClassEntity> Classes { get; set; }
}