using IOLibrary;

const int NUMBER_OF_CARS = 2;
Driver[] drivers = GetDrivers();

int sumOfFuel = drivers.Sum(x => x.Fuel);
Console.WriteLine($"\nA vezetők összesen {sumOfFuel}L-nyi üzemanyagot tankoltak");

Console.WriteLine("Autók, akik 40L fölött tankoltak: \n");
Driver[] fuelOver40Liters = drivers.Where(x => x.Fuel > 40).ToArray();
WriteArraytoConsole(fuelOver40Liters);

Driver mostFuelPumped = getMostFuelPumped(drivers);
Console.WriteLine($"\nA legtöbbet a(z) '{mostFuelPumped.LicenseNumber}' rendszámú tankolt, {mostFuelPumped.Fuel}L-nyit");

Driver leastFuelPumped = getLeastFuelPumped(drivers);
Console.WriteLine($"\nA legkevesebbet a(z) '{leastFuelPumped.LicenseNumber}' rendszámú tankolt, {leastFuelPumped.Fuel}L-nyit");

int allBelow30Liters = drivers.Count(x => x.Fuel < 30);
Console.WriteLine($"\n{allBelow30Liters} ember tankolt 30 liter alatt");

bool tanked50Exactly = drivers.Any(x => x.Fuel == 50);
Console.WriteLine($"\n{(tanked50Exactly ? "Volt" : "Nem volt")} olyan autós aki 50L-t tankolt pontosan");

Driver getMostFuelPumped(Driver[] drivers)
{
	int mostFuel = drivers.Max(x => x.Fuel);
	Driver mostFuelPumped = drivers.First(x => x.Fuel == mostFuel);

	return mostFuelPumped;
}

Driver getLeastFuelPumped(Driver[] drivers)
{
	int leastFuel = drivers.Min(x => x.Fuel);
	Driver leastFuelPumped = drivers.First(x => x.Fuel == leastFuel);

	return leastFuelPumped;
}

Driver[] GetDrivers()
{
	Driver[] drivers = new Driver[NUMBER_OF_CARS];
	for (int i = 0; i < NUMBER_OF_CARS; i++)
	{
		string licenseNum = ExtendedConsole.ReadString($"\nAdd meg a rendszámát a(z) {i + 1}. vezetőnek > ");
		int fuel = ExtendedConsole.ReadInteger($"Add meg mennyit litert tankolt a(z) {i + 1}. vezető > ", int.MaxValue, 0);
		int cost = GetCost(fuel);

		Driver driver = new Driver(licenseNum, fuel, cost);
		drivers[i] = driver;
	}
	return drivers;
}

void WriteArraytoConsole(Driver[] drivers)
{
	foreach (Driver driver in drivers)
	{
        Console.WriteLine(driver);
    }
}

int GetCost(int fuel)
{
	int finalCost = fuel * 585;
	return finalCost;
}