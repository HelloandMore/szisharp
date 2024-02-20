public class Book
{
	public string Name { get; set; }
	public double Average { get; set; }

	public Book() { }

	public Book(string name, double average)	{
		Name = name;
		Average = average;
	}

	public override string ToString()
	{
		return $"{this.Name} -> {this.Average}";
	}
}