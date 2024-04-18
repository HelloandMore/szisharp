public class Gpu : Hardware
{

	public int Memory { get; set; }
	public string MemoryType { get; set; }

	public Gpu(): base() { }

	public Gpu(string manufacturer, string model, string type, int memory, string memoryType)
		: base(manufacturer, model, type)
	{
		Memory = memory;
		MemoryType = memoryType;
	}

	public override string ToString()
	{
		return base.ToString() + $", Memory: {Memory} GB, Memory Type: {MemoryType}";
	}
}