﻿using System.Text;

public static class FileService
{
	public static void WriteCollectionToFile<T>(string fileName, ICollection<T> absences) where T : class
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.csv");

		StringBuilder sb = new StringBuilder();

		foreach (var absence in absences)
		{
			sb.AppendLine(absence.ToString());
		}

		File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
	}

	public static void WriteCollectionToFileString(string fileName, Dictionary<string, List<string>> absences)
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.csv");

		StringBuilder sb = new StringBuilder();

		foreach (var item in absences)
		{
			sb.AppendLine($"{item.Key}:");
			foreach (var name in item.Value)
			{
				sb.AppendLine($"\t- {name}");
			}
		}

		File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
	}

	public static async Task<List<Absence>> ReadFromFileAsyncV2(string fileName)
	{
		List<Absence> absents = new List<Absence>();
		Absence absent = null;
		string[] data = null;


		string path = Path.Combine("source", fileName);
		File.ReadAllLinesAsync(path, Encoding.UTF8);

		string[] lines = await File.ReadAllLinesAsync(path, Encoding.UTF8);

		foreach (string line in lines.Skip(1))
		{
			data = line.Split(";");
			absent = new Absence();
			absent.Name = data[0];
			absent.Class = data[1];
			absent.FirstDay = int.Parse(data[2]);
			absent.LastDay = int.Parse(data[3]);
			absent.Hours = int.Parse(data[4]);

			absents.Add(absent);
		}

		return absents;
	}
}