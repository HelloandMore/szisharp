using System.Text;

public static class FileService
{
	public static void WriteCollectionToFile<T>(string fileName, ICollection<T> players) where T : class
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.csv");

		StringBuilder sb = new StringBuilder();

		foreach (var player in players)
		{
			sb.AppendLine(player.ToString());
		}

		File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
	}

	public static void WriteCollectionToFileString(string fileName, Dictionary<string, List<string>> players)
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.csv");

		StringBuilder sb = new StringBuilder();

		foreach (var item in players)
		{
			sb.AppendLine($"{item.Key}:");
			foreach (var name in item.Value)
			{
				sb.AppendLine($"\t- {name}");
			}
		}

		File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
	}

	public static async Task<List<Player>> ReadFromFileAsync(string fileName)
	{
		List<Player> players = new List<Player>();
		Player player = null;
		string[] data = null;


		string path = Path.Combine("source", fileName);
		File.ReadAllLinesAsync(path, Encoding.UTF8);

		string[] lines = await File.ReadAllLinesAsync(path, Encoding.UTF8);

		foreach (string line in lines.Skip(1))
		{
			data = line.Split(";");
			player = new Player
			{
				Name = data[0],
				FirstTime = DateTime.Parse(data[1]),
				LastTime = DateTime.Parse(data[2]),
				Weight = int.Parse(data[3]),
				Height = int.Parse(data[4])
			};

			players.Add(player);
		}

		return players;
	}
}