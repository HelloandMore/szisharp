namespace Lecso.Database.Entities;

[Table("Competition")]

public class CompetitionEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual IReadOnlyCollection<JudgeEntity> Judges { get; set; }

    [ForeignKey("Location")]
    public uint LocationPostalCode { get; set; }
    public virtual LocationEntity Location { get; set; }

    public virtual IReadOnlyCollection<TeamsEntity> Teams { get; set; }
}
