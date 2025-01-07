namespace Lecso.Database.Entities;

[Table("Judge")]
[Index(nameof(PhoneNumber), IsUnique = true)]


public class JudgeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(12)]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    public virtual IReadOnlyCollection<CompetitionEntity> Competitions { get; set; }
}