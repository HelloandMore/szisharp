namespace Diary.Database.Entites;
[Table("Student")]

public class StudentEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int EduId { get; set; }

	[Required]
	[StringLength(50)]
	public string Name { get; set; }

	[Required]
	public DateTime DateOfBirth { get; set; }

	[Required]
	public string MotherName { get; set; }

	public int? AddressId { get; set; }

	public virtual AddressEntity Address { get; set; }

	public virtual ICollection<GradeEntity> Grades { get; set; }

	public virtual ICollection<SubjectEntity> Subjects { get; set; }
}
