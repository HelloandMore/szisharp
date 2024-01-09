public class Driver
{
	public string LicenseNumber { get; set; }
	public int Fuel { get; set; }
	public int Cost { get; set; }

	public Driver(string licenseNumber, int fuel, int cost)
	{
		this.LicenseNumber = licenseNumber;
		this.Fuel = fuel;
		this.Cost = cost;
	}

	public override string ToString()
	{
		return $"{this.LicenseNumber.ToString().PadLeft(7)} - {this.Fuel.ToString().PadLeft(3)} liter üzemanyagot tankolt {this.Cost.ToString().PadLeft(5)} Ft-ért";
	}
}

