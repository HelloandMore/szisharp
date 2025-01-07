namespace OOT.Database.Entities;

[Table("Subclass")]

public class SubclassEntity
{
    [Key]
    public uint Id { get; set; }

    [Required]
    public string SubclassName { get; set; }

    [ForeignKey("Class")]
    public uint ClassId { get; set; }
    public virtual ClassEntity Class { get; set; }

    public virtual IReadOnlyCollection<TribeEntity> Tribes { get; set; }
}