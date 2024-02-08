
public class MotorOrdered
{
	public string MotorName { get; set; }

	public int ReleasYear { get; set; }

	public MotorOrdered() { }

	public MotorOrdered(string motorName, int releasYear)
	{
		MotorName = motorName;
		ReleasYear = releasYear;
	}
}