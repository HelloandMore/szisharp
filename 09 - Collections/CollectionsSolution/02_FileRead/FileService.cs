public static class FileService
{
	#region File Read
	public static async Task<List<Books>> ReadFromFileAsync(string fileName)
	{
		List<Books> books = new List<Books>();
		Books? book = null;
		string line = string.Empty;
		string[]? data = null;

		string path = Path.Combine("source", fileName);

		using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
		using StreamReader sr = new StreamReader(fs, Encoding.UTF8);

		await sr.ReadLineAsync(); //kiolvassa a fejleceket, csak epp nem csinalunk vele semmit

		while (!sr.EndOfStream)
		{
			line = await sr.ReadLineAsync();
			data = line.Split("\t");
			book = new Books();
			book.WriterFirstName = data[0];
			book.WriterLastName = data[1];
			book.BirthDate = DateTime.Parse(data[2]);
			book.Title = data[3];
			book.ISBN = data[4];
			book.Publisher = data[5];
			book.PublishYear = int.Parse(data[6]);
			book.Price = int.Parse(data[7]);
			book.Topic = data[8];
			book.PageCount = int.Parse(data[9]);
			book.Honorarium = int.Parse(data[10]);


			books.Add(book);
		}

		return books;
	}
	#endregion
	#region File Write
	public static async Task WriteCollectionToFile(string fileName, ICollection<Books> books)
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.txt");
		List<string> data = new List<string>();

		using FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.None, 128);
		using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

		foreach (Books book in books)
		{
			data.Add($"{book}");
		}

		File.WriteAllLinesAsync(path, data, Encoding.UTF8);
	}

	public static async Task WriteCollectionToFileString(string fileName, ICollection<string> books)
	{
		Directory.CreateDirectory("output");
		string path = Path.Combine("output", $"{fileName}.txt");
		List<string> data = new List<string>();

		using FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.None, 128);
		using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

		foreach (String book in books)
		{
			data.Add($"{book}");
		}

		File.WriteAllLinesAsync(path, data, Encoding.UTF8);
	}
	#endregion
}