namespace AtletikaBajnoksag.Database.Entities;

[Table("Competition")]
public class CompetitionEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual IReadOnlyCollection<CompetitionNumberEntity> CompetitionNumber { get; set; }

    [ForeignKey("Location")]
    public uint LocationId { get; set; }
    public virtual LocationEntity Location {  get; set; }
}
