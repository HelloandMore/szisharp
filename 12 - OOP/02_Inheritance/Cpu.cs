public class Cpu : Hardware
{
	public int numOfCores { get; set; }
	public double Frequency { get; set; }

	public Cpu() : base() { }

	public Cpu(string manufacturer, string model, string type, int numOfCores, double frequency)
		: base(manufacturer, model, type)
	{
		this.numOfCores = numOfCores;
		Frequency = frequency;
	}

	public Cpu(int numOfCores, double frequency)
	{
		this.numOfCores = numOfCores;
		Frequency = frequency;
	}

	public override string ToString()
	{
		return base.ToString() + $", Cores: {numOfCores}, Frequency: {Frequency} GHz";
	}
}