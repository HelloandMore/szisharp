public class PlayerByPositions
{
	public string Position { get; set; }
	public int CountByPos { get; set; }

	public PlayerByPositions() { }

	public PlayerByPositions(string position, int countByPos)
	{
		this.Position = position;
		this.CountByPos = countByPos;
	}
}
