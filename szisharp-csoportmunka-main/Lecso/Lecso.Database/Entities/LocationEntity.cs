namespace Lecso.Database.Entities;

[Table("Location")]

public class LocationEntity
{
	[Key]
	[Required]
	[Range(1000, 9999)]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public uint PostalCode { get; set; }

	[Required]
	public string Name { get; set; }

	[Required]
	public string StreetName { get; set; }

	[Required]
	public int HouseNumber { get; set; }

	public virtual IReadOnlyCollection<CompetitionEntity> Competitions { get; set; }
}