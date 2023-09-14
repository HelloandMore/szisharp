public class Motorcycle
{

	public string Manufacturer { get; set; }

	public string Model { get; set; }

	public int ProductionYear { get; set; }

	public override string ToString()
	{
		return $"{this.Manufacturer} {this.Model} ({this.ProductionYear})";
	}
}
