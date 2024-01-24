public class TallSmall
{
	public Player TallestPlayer { get; set; }
	public Player ShortestPlayer { get; set; }
	public int TallSmallDifference { get; }

	public TallSmall (Player tallest, Player shortest)
	{
		this.TallestPlayer = tallest;
		this.ShortestPlayer = shortest;
		this.TallSmallDifference = tallest.Height-shortest.Height;
	}
    public override string ToString()
    {
        return $"A legmagasabb játékos {TallestPlayer.Name} ({TallestPlayer.Height} cm)\nA legalacsonyabb játékos: {ShortestPlayer.Name} ({ShortestPlayer.Height} cm)\nA különbség: {TallSmallDifference} cm";
    }
}