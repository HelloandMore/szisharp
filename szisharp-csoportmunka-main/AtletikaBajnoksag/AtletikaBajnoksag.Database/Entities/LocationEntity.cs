using Microsoft.EntityFrameworkCore.Storage;

namespace AtletikaBajnoksag.Database.Entities;
[Table("Location")]
public class LocationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [ForeignKey("City")]
    public uint CityPostalCode { get; set; }
    public virtual CityEntity City { get; set; }

    [Required]
    public string StreetName { get; set; }

    [Required]
    public int HouseNumber { get; set; }

    public virtual OrganizationEntity Organization { get; set; }

    public virtual IReadOnlyCollection<CompetitionEntity> Competitions { get; set; }

    public virtual IReadOnlyCollection<CompetitorEntity> Competitors { get; set; }
}
