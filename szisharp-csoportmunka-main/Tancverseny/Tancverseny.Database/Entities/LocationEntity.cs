namespace Tancverseny.Database.Entities;


[Table("Location")]
public class LocationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [ForeignKey("City")]
    public uint CityId { get; set; }
    public virtual CityEntity City { get; set; }

    [Required]
    [StringLength(60)]
    public string StreetName { get; set; }

    [Required]
    public int HouseNumber { get; set; }

    public virtual IReadOnlyCollection<CompetitionEntity> Competitions { get; set; }
}
