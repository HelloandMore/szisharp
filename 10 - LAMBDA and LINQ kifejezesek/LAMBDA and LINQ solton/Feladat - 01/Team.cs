
using System.Collections.Generic;
using System.Text;

public class Team
{
	public string Name { get; set; }
	public List<string> PlayersName { get; set; }

	public Team() { }

	public Team(string teamName, List<string> playerName)
	{
		Name = teamName;
		PlayersName = playerName;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(Name);
		foreach (string playerName in PlayersName)
		{
			sb.AppendLine($"\t-{playerName}");
		}
		return sb.ToString();
	}
}