using System.Text;

public static class FileService
{
	public static async Task<List<DanceTypeAndCoupleNames>> GetDanceTypeAndCoupleNames(string fileName)
	{
		List<DanceTypeAndCoupleNames> result = new List<DanceTypeAndCoupleNames>();
		DanceTypeAndCoupleNames dance = null;
		string path = Path.Combine("../../../source", fileName);

		using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
		using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

		while (!sr.EndOfStream)
		{
			dance = new DanceTypeAndCoupleNames();

			dance.DanceName = await sr.ReadLineAsync();
			dance.GirlName = await sr.ReadLineAsync();
			dance.BoyName = await sr.ReadLineAsync();

			result.Add(dance);
		}

		return result;

	}

	public static async Task WriteListToFileAsync(List<string> girlDancers, List<string> boyDancers, string fileName)
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.txt");

		using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
		using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

		await sw.WriteAsync("Lányok: ");
		for (int i = 0; i < girlDancers.Count; i++)
		{
			await sw.WriteAsync($"{girlDancers[i]}");
			if (i < girlDancers.Count - 1)
			{
				await sw.WriteAsync(", ");
			}
		}
		await sw.WriteLineAsync();
		await sw.WriteAsync("Fiúk: ");
		for (int i = 0; i < boyDancers.Count; i++)
		{
			await sw.WriteAsync($"{boyDancers[i]}");
			if (i < boyDancers.Count - 1)
			{
				await sw.WriteAsync(", ");
			}
		}
	}
}

