public class Student
{
	public string Name { get; set; }
	public int Grade { get; set; }
	public int Points { get; set; }

	public Student(string name, int grade, int points)
	{
		this.Name = name;
		this.Grade = grade;
		this.Points = points;
	}
}
