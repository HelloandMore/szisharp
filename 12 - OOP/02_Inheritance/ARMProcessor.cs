public class ARMProcessor : Cpu
{
	public int NumberOfPowerCores { get; set; }
	public int NumberOfEfficientCores { get; set; }

	public ARMProcessor() : base()
	{

	}

	public ARMProcessor(int numberOfPowerCores, int numberOfEfficientCores, int numOfCores, double frequency) : base(numOfCores, frequency)
	{
		NumberOfPowerCores = numberOfPowerCores;
		NumberOfEfficientCores = numberOfEfficientCores;
	}
}