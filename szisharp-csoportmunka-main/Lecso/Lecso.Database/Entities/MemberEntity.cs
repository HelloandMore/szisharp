namespace Lecso.Database.Entities;

[Table("Member")]

public class MemberEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public uint Id { get; set; }

	[Required]
	[ForeignKey("Teams")]
	public uint TeamId { get; set; }
	public virtual TeamsEntity Team { get; set; }

	[StringLength(60)]
	[Required]
	public string Name { get; set; }

}