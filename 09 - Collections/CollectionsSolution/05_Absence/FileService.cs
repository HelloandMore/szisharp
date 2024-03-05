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

	public static void WriteCollectionToFileString(string fileName, Dictionary<string, List<string>> playersByTeam)
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.csv");

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

	public static List<string> ReadFile(string fileName)
	{
		string path = Path.Combine("input", fileName);
		return File.ReadAllLines(path, Encoding.UTF8).ToList();
	}
}