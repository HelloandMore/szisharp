namespace Diary.Database.Entites;
[Table("Subject")]

public class SubjectEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	public string SubjectName { get; set; }

	public virtual ICollection<StudentEntity> Students { get; set; }

	public virtual ICollection<GradeEntity> Grades { get; set; }
}
