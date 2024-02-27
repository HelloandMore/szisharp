using System.Text;

public class Player
{
	public string Name { get; set; }
	public int Height { get; set; }
	public string Position { get; set; }
	public string National { get; set; }
	public string Team { get; set; }
	public string Country { get; set; }

	public Player(string name, int height, string position, string national, string team, string country)
	{
		this.Name = name;
		this.Height = height;
		this.Position = position;
		this.National = national;
		this.Team = team;
		this.Country = country;
	}
	public override string ToString()
	{
		return $"{this.Name} ({this.National}) - {this.Height} cm, {this.Position}, {this.Team}, {this.Country}";
	}
}