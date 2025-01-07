

namespace Tancverseny.Database.Entities;

[Table("Competition")]
public class CompetitionEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [ForeignKey("Location")]
    public uint LocationId { get; set; }
    public virtual LocationEntity Location { get; set; }

    [Required]
    public DateTime BeginDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

   public virtual IReadOnlyCollection<GroupEntity> Groups { get; set; }

}
