namespace Tancverseny.Database.Entities;

[Table("Country")]

public class CountryEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string CountryName { get; set; }

    public virtual IReadOnlyCollection<CityEntity> Cities { get; set; }
}
