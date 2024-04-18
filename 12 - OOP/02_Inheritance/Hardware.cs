public abstract class Hardware
{
	protected string Manufacturer { get; set; }
	protected string Model { get; set; }
	protected string Type { get; set; }

	protected Hardware() { }

	protected Hardware(string manufacturer, string model, string type)
	{
		Manufacturer = manufacturer;
		Model = model;
		Type = type;
	}

	public override string ToString()
	{
		return $"Manufacturer: {Manufacturer}, Model: {Model}, Type: {Type}";
	}
}