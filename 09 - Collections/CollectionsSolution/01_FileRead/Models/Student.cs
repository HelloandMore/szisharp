public class Student
{
	public string Name { get; set; }
	public double Average { get; set; }

	public Student() { }

	public Student(string name, double average)	{
		Name = name;
		Average = average;
	}

	public override string ToString()
	{
		return $"{this.Name} -> {this.Average}";
	}
}