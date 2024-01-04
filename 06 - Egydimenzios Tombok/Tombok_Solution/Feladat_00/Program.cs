using IOLibrary;

const int NUMBER_OF_CARS = 4;
Driver[] drivers = GetDrivers();
int sumOfFines = drivers.Sum(x => x.Fine);
Console.WriteLine($"\nA hatóság összesen {sumOfFines} Ft-nyi büntetést szabott ki");

Driver fastestDriver = GetFastestDriver(drivers);
Console.WriteLine($"\nA leggyorsabban a(z) '{fastestDriver.LicenseNumber}' rendszámú autó hajtott {fastestDriver.CapturedSpeed} sebességgel");

int numOfNonSpeedingDrivers = drivers.Count(x => x.CapturedSpeed <= 90);
Console.Write($"\n{numOfNonSpeedingDrivers} ember vezetett szabályosan, ami a(z) ");

double tempPercentage = (double)numOfNonSpeedingDrivers / NUMBER_OF_CARS;
Console.WriteLine($"{tempPercentage*100:F2}%-a a vezetőknek.");

bool goingAt60 = drivers.Any(x => x.CapturedSpeed == 60);
Console.WriteLine($"\n{(goingAt60 ? "Volt" : "Nem volt")} olyan autós aki 60-al ment");





Driver GetFastestDriver(Driver[] drivers)
{
	int fastestSpeed = drivers.Max(x => x.CapturedSpeed);
	Driver fastestCar = drivers.First(x => x.CapturedSpeed == fastestSpeed);

	return fastestCar;
}

Driver[] GetDrivers()
{
	Driver[] drivers = new Driver[NUMBER_OF_CARS];
	for (int i = 0; i < NUMBER_OF_CARS; i++)
	{
		string licenseNum = ExtendedConsole.ReadString($"\nAdd meg a rendszámát a(z) {i+1}. vezetőnek > ");
		int speed = ExtendedConsole.ReadInteger($"Add meg mennyivel ment a(z) {i+1}. vezető > ", int.MaxValue, 1);
		int fine = GetFine(speed);

		Driver driver = new Driver(licenseNum, speed, fine);
		drivers[i] = driver;
	}
	return drivers;
}

int GetFine(int speed)
{
	switch (speed)
	{
		case > 110:
			return 30000;
		case > 101:
			return 20000;
		case > 91:
			return 10000;
		default:
			return 0;
	}
}