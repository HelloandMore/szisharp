using System.Text;

public static class FileService
{
	//modszer 1
	public static async Task<List<Student>> ReadFromFileAsync(string fileName) {  
		
		List<Student> students = new List<Student>();
		Student student = null;
		string line = string.Empty;
		string[] data = null;

		string path = Path.Combine("source", fileName);

		using FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
		using StreamReader sr = new StreamReader(fs, Encoding.UTF8);

		while (!sr.EndOfStream)
		{
			line = await sr.ReadLineAsync();
			data = line.Split("\t");

			student = new Student();
			student.Name = data[0];
			student.Average = double.Parse(data[1]);

			students.Add(student);
		}

		return students;
	}
}