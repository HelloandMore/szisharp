public class DataManager
{
	public List<Student> Students { get; set; }
	public List<Class> Classes { get; set; }
	public DataManager()
	{
		Students = new List<Student>();
		Classes = new List<Class>();
	}
	public void AddStudent(Student student)
	{
		student.Id = Students.Count + 1;
		Students.Add(student);
	}
	public void AddClass(Class clas)
	{
		clas.Id = Classes.Count + 1;
		Classes.Add(clas);
	}
	public void ModifyStudent(Student student)
	{
		var studentIndex = Students.FindIndex(d => d.Id == student.Id);
		if (studentIndex != -1)
		{
			Students[studentIndex] = student;
		}
	}
	public void ModifyClass(Class clas)
	{
		var classIndex = Classes.FindIndex(t => t.Id == clas.Id);
		if (classIndex != -1)
		{
			Classes[classIndex] = clas;
		}
	}
public void RemoveStudent(int id)
	{
		var student = Students.FirstOrDefault(d => d.Id == id);
		if (student != null)
		{
			Students.Remove(student);
		}
	}
	public void RemoveClass(int id)
	{
		var clas = Classes.FirstOrDefault(t => t.Id == id);
		if (clas != null)
		{
			Classes.Remove(clas);
		}
	}
	public Student GetStudent(int id)
	{
		return Students.FirstOrDefault(d => d.Id == id);
	}
	public Class GetClass(int id)
	{
		return Classes.FirstOrDefault(t => t.Id == id);
	}
	public void SaveToFile(string fileName)
	{
		var lines = Students.Select(d => $"{d.Id};{d.Name};{string.Join(",", d.Classes.Select(t => $"{t.Name}:{string.Join(",", t.Grades)}"))}");
		File.WriteAllLines(fileName, lines);
	}
	public void LoadFromFile(string fileNev)
	{
		Students = File.ReadAllLines(fileNev).Select(s =>
		{
			var split = s.Split(';');
			return new Student
			{
				Id = int.Parse(split[0]),
				Name = split[1],
				Classes = split[2].Split(',').Select(t =>
				{
					var tSplit = t.Split(':');
					return new Class
					{
						Name = tSplit[0],
						Grades = tSplit[1].Split(',').Select(int.Parse).ToList()
					};
				}).ToList()
			};
		}).ToList();
	}
}