namespace Tancverseny.Database.Entities;

[Table("City")]

public class CityEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public string PostalCode { get; set; }

    [Required]
    public string CityName { get; set; }

    [ForeignKey("Country")]
    public uint CountryId { get; set; }
    public virtual CountryEntity Country { get; set; }

    public virtual IReadOnlyCollection<LocationEntity> Locations { get; set; }
}
