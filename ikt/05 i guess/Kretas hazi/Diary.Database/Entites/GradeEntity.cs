namespace Diary.Database.Entites;
[Table("Grade")]

public class GradeEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	public int SubjectId { get; set; }

	[Required]
	public int GradeValue { get; set; }

	public virtual SubjectEntity Subject { get; set; }

	public virtual StudentEntity Student { get; set; }
}
