namespace OOT.Database.Entities;

[Table("Watching")]

public class WatchingEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public string Location { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [ForeignKey("Bird")]
    public uint BirdRingId { get; set; }
    public virtual BirdEntity Bird { get; set; }

    [ForeignKey("Member")]
    public uint MemberId { get; set; }
    public virtual MemberEntity Member { get; set; }
}
