namespace OOT.Database.Entities;

[Table("Member")]

public class MemberEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public uint CardNumber { get; set; }

    [ForeignKey("Location")]
    public uint LocationPostalCode { get; set; }
    public virtual LocationEntity Location { get; set; }

    [Required]
    public DateTime MemberSince { get; set; }

    public DateTime MemberUntil { get; set; }

    public virtual IReadOnlyCollection<BirdEntity> RingedBirds { get; set; }

    public virtual IReadOnlyCollection<WatchingEntity> Watchings { get; set; }
}
