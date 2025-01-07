namespace Tancverseny.Database.Entities;

public class ParticipantEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [ForeignKey("Location")]
    public uint LocationId { get; set; }
    public virtual LocationEntity Location { get; set; }


    [ForeignKey("Group")]
    public uint GroupId { get; set; }
    public virtual GroupEntity Group { get; set; }
}
