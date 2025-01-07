namespace OOT.Database.Entities;

[Table("Tribe")]

public class TribeEntity
{
    [Key]
    public uint Id { get; set; }

    [Required]
    public string TribeName { get; set; }

    [ForeignKey("Subclass")]
    public uint SubclassId { get; set; }
    public virtual SubclassEntity Subclass { get; set; }
}