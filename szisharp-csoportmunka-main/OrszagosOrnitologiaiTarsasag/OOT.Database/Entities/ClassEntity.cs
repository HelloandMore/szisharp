namespace OOT.Database.Entities;

[Table("Class")]

public class ClassEntity
{
    [Key]
    public uint Id { get; set; }

    [Required]
    public string ClassName { get; set; }

    [ForeignKey("Species")]
    public uint SpeciesId { get; set; }
    public virtual SpeciesEntity Species { get; set; }

    public virtual IReadOnlyCollection<SubclassEntity> Subclasses { get; set; }
}