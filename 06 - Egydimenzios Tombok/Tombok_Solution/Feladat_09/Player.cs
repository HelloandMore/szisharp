public class Player
{
	public string Name { get; set; }
	public int Height { get; set; }
	public int sumOfPoints {  get; set; }

	public Player(string name, int numOfGoals, int sumOfPoints)
	{
		this.Name = name;
		this.Height = numOfGoals;
		this.sumOfPoints = sumOfPoints;
	}
	public override string ToString()
	{
		return $"{this.Name} ({this.Height} cm)";
	}
}