namespace Tancverseny.Database.Entities;


[Table("Group")]
public class GroupEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string GroupName { get; set; }

    [Required]
    public string Choreographer { get; set; }

    [Required]
    public int Points { get; set; }

    public virtual IReadOnlyCollection<ParticipantEntity> Participants { get; set; }

    public virtual IReadOnlyCollection<CompetitionEntity> Competitions { get; set; }
}
