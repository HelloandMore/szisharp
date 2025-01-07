namespace AtletikaBajnoksag.Database.Entities;

[Table("Competitor")]
public class CompetitorEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public GenderEnum Gender { get; set; }

    [Required]
    public AgeGroupEnum AgeGroup { get; set; }

    [ForeignKey("Location")]
    public uint LocationId { get; set; }
    public virtual LocationEntity Location { get; set; }

    [ForeignKey("CompetitionNumber")]
    public uint CompetitionNumberId { get; set; }
    public virtual CompetitionNumberEntity CompetitionNumber { get; set; }

    [ForeignKey("Organization")]
    public uint OrganizationId { get; set; }
    public virtual OrganizationEntity Organization { get; set; }

    [ForeignKey("Supervisor")]
    public uint? SupervisorId { get; set; }
    public virtual SupervisorEntity Supervisor { get; set; }
}
