namespace OOT.Database.Entities;

[Table("Bird")]

public class BirdEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint RingId { get; set; }

    [Required]
    public DateTime RingingDate { get; set; }

    public string RingingLocation { get; set; }

    [ForeignKey("Classification")]
    public uint ClassificationId { get; set; }
    public virtual ClassificationEntity Classification { get; set; }

    [ForeignKey("Member")]
    public uint MemberId { get; set; }
    public virtual MemberEntity Ringer { get; set; }

    public virtual IReadOnlyCollection<WatchingEntity> Watchings { get; set; }
}