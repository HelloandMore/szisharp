using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lecso.Database.Entities;

[Table("Teams")]

public class TeamsEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public uint Id { get; set; }

	[StringLength(60)]
	[Required]
	public string Name { get; set; }

	[Required]
	public int Points { get; set; }


	public uint MemberTeamId { get; set; }
	public virtual IReadOnlyCollection<MemberEntity> Members { get; set; }

	public virtual IReadOnlyCollection<CompetitionEntity> Competitions { get; set; }
}