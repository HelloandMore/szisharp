namespace AtletikaBajnoksag.Database.Entities;

[Table("Supervisor")]
public class SupervisorEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    public virtual IReadOnlyCollection<CompetitorEntity> Competitors { get; set; }

}
