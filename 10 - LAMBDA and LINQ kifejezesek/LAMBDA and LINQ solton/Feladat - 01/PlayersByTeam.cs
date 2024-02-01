public class PlayersByTeam
{
	public string Name { get; set; }
	public string Team { get; set; }

	public PlayersByTeam() { }

	public PlayersByTeam(string name, string team)
	{
		this.Name = name;
		this.Team = team;
	}
}
