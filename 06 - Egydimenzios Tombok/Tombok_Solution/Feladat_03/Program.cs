using IOLibrary;

const int NUMBER_OF_FRUITS = 2;

Fruit[] fruits = GetFruits();

double sumOfWeight = fruits.Sum(x => x.Weight);
Console.WriteLine($"Gyümölcsök összsúlya: {sumOfWeight}");

WriteFruitsSum(fruits);

double totalPrice = fruits.Sum(x => x.Weight * x.Price);
Console.WriteLine($"A gyümölcsök teljes ára: {totalPrice}");

double topPrice = fruits.Max(x => x.Price);
Fruit mostExpensive = fruits.First(x => x.Price == topPrice);
Console.WriteLine($"A legdrágább gyümölcs: {mostExpensive}");

double weightsLightest = fruits.Min(x =>  x.Weight);
Fruit leastHeavy = fruits.First(x => x.Weight == weightsLightest);
Console.WriteLine($"A legkönnyebb gyümölcs: {leastHeavy}");

Fruit[] below100kg = fruits.Where(x => x.Weight < 100).ToArray();
Console.WriteLine("\nGyümölcsök 100 kg alatt:");
WriteArrayToConsole(below100kg);

Fruit[] over1500Forints = fruits.Where(x => x.Price > 1500).ToArray();
Console.WriteLine("\nGyümölcsök 1500 Ft alatt:");
WriteArrayToConsole(over1500Forints);

Fruit[] GetFruits()
{
	Fruit[] fruits = new Fruit[NUMBER_OF_FRUITS];
	for (int i = 0; i < NUMBER_OF_FRUITS; i++)
	{
		string name = ExtendedConsole.ReadString("\nAdd meg a gyümölcs nevét > ");
		double weight = ExtendedConsole.ReadDouble("Add meg hány kg van az adott gyümölcsből > ");
		double price = ExtendedConsole.ReadDouble("Add meg az árát (db) > ");

		Fruit fruit = new Fruit(name, weight, price);

		fruits[i] = fruit;
	}
	return fruits;
}

void WriteFruitsSum(Fruit[] fruits)
{
	foreach (Fruit fruit in fruits)
	{
		Console.WriteLine($"{fruit.Name} teljes ára: {fruit.Price * fruit.Weight} Ft");
	}
}

void WriteArrayToConsole(Fruit[] fruits)
{
	foreach (Fruit fruit in fruits)
	{
        Console.WriteLine(fruit);
    }
}