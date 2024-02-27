using System.Text;

public static class FileService
{
	public static void WriteCollectionToFile<T>(string fileName, ICollection<T> players) where T : class
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.txt");

		StringBuilder sb = new StringBuilder();

		foreach (var player in players)
		{
			sb.AppendLine(player.ToString());
		}

		File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
	}

	public static void WriteCollectionToFileString(string fileName, Dictionary<string, List<string>> playersByTeam)
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.txt");

		StringBuilder sb = new StringBuilder();

		foreach (var item in playersByTeam)
		{
			sb.AppendLine($"{item.Key}:");
			foreach (var name in item.Value)
			{
				sb.AppendLine($"\t- {name}");
			}
		}

		File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
	}

	public static List<Player> ReadPlayersFromFile(string fileName)
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.txt");

		List<string> players = File.ReadAllLines($"../../../{fileName}").ToList();
		List<Player> playerList = new List<Player>();

		foreach (var player in players)
		{
			string[] data = player.Split('\t');
			playerList.Add(new Player(data[0], int.Parse(data[1]), data[2], data[3], data[4], data[5]));
		}

		return playerList;
	}
}