using IOLibrary;
const int NUM_OF_TRUCKS = 7;


Truck[] trucks = GetTrucks();

Console.Clear();
WriteArrayToConsole(trucks);

double weightSum = trucks.Sum(x => x.Weight);
Console.WriteLine($"A kamionok összsúlya: {weightSum}");

double averageWeight = trucks.Average(x => x.Weight);
Console.WriteLine($"Átlagsúlyuk: {averageWeight}");

double heaviestTruck = trucks.Max(x => x.Weight);
Truck mostWeight = trucks.First(x => x.Weight == heaviestTruck);
Console.WriteLine($"Legnehezebb kamion: {mostWeight}");

bool WereThere10Tonnes = trucks.Any(x => x.Weight.Equals(10));
Console.WriteLine($"\n{(WereThere10Tonnes?"Volt":"Nem volt")} 10 tonnás kamion");

Truck[] heavierThan10T = trucks.Where(x => x.Weight > 10).ToArray();
Console.WriteLine("\n10 tonnánál nehezebb kamionok:");
WriteTruckLicense(heavierThan10T);


Console.Write($"\nA legkönnyebb kamion a(z) ");
lightestTruckRow(trucks);
Console.WriteLine(" sorban volt");





Truck[] GetTrucks()
{
	Truck[] trucks = new Truck[NUM_OF_TRUCKS];
	for (int i = 0; i < NUM_OF_TRUCKS; i++)
	{
		string licensePlate = ExtendedConsole.ReadString($"Add meg a(z) {i + 1}. kamion rendszámát > ");
		int weight = new Random().Next(3500, 40000);

		trucks[i] = new Truck(licensePlate, weight / 1000);
	}
	return trucks;
}

int lightestTruckRow(Truck[] trucks)
{
	int counter = 0;
	double lighest = trucks.Min(x => x.Weight);
	foreach (Truck truck in trucks)
	{
		counter++;

		if (truck.Weight == lighest)
		{
			break;
		}
	}
	return counter;
}

void WriteTruckLicense(Truck[] trucks)
{
	foreach(Truck truck in trucks)
	{
        Console.WriteLine($"{truck.LicensePlate}");
    }
}

void WriteArrayToConsole(object[] items)
{
	foreach(object item in items)
	{
		Console.WriteLine(item);
	}
}