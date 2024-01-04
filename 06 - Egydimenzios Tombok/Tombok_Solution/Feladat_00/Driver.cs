public class Driver
{
	public string LicenseNumber { get; set; }
	public int CapturedSpeed { get; set; }
	public int Fine { get; set; }

	public Driver(string licenseNumber, int capturedSpeed, int fine)
	{
		this.LicenseNumber = licenseNumber;
		this.CapturedSpeed = capturedSpeed;
		this.Fine = fine;
	}

	public override string ToString()
	{
		return $"{this.LicenseNumber.ToString().PadLeft(7)} {this.CapturedSpeed.ToString().PadLeft(3)} sebességgel hajtott, {this.Fine.ToString().PadLeft(5)} Ft bírság";
	}
}

