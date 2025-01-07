namespace Diary.Database.Entites;

[Table("Address")]
public class AddressEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	[Required]
	[StringLength(50)]
	public string Street { get; set; }
	[Required]
	[StringLength(50)]
	public string City { get; set; }
	[Required]
	[StringLength(50)]
	public string HouseNumber { get; set; }
	[Required]
	[StringLength(50)]
	public string Country { get; set; }
	
	public ICollection<StudentEntity> Students { get; set; }
}
