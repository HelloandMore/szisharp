public class Player
{
	public string Name { get; set; }
	public int goalNumber { get; set; }

	public Player()
	{

	}

	public Player(string name, int goalNumber)
	{
		Name = name;
		this.goalNumber = goalNumber;
	}

	public override string ToString()
	{
		return $"{Name} - {goalNumber} gól";
	}
}