public class GradeWithPoints
{
	public int Grade { get; set; }
	public int Points { get; set; }

	public GradeWithPoints()
	{

	}
	public GradeWithPoints(int grade, int points)
	{
		this.Grade = grade;
		this.Points = points;
	}
}