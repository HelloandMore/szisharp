public class RamMemory : Hardware
{
	public int Capacity { get; set; }
	public int Frequency { get; set; }

	public RamMemory():base() { }

	public RamMemory(string manufacturer, string model, string type, int capacity, int frequency)
		: base(manufacturer, model, type)
	{
		Capacity = capacity;
		Frequency = frequency;
	}

	public override string ToString()
	{
		return base.ToString() + $", Capacity: {Capacity} GB, Frequency: {Frequency} MHz";
	}
}