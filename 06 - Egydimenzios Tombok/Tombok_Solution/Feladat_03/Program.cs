using IOLibrary;

const int NUMBER_OF_FRUITS = 10;

Fruit[] fruits = GetFruits();

double sumOfWeight = fruits.Sum(x => x.Weight);
Console.WriteLine($"Gyümölcsök összsúlya: {sumOfWeight}");

WriteArrayToConsole(fruits);

double totalPrice = fruits.Sum(x => x.Weight * x.Price);
Console.WriteLine($"A gyümölcsök teljes ára: {totalPrice}");

double topPrice = fruits.Max(x => x.Price);
Fruit mostExpensive = fruits.First(x => x.Price == topPrice);
Console.WriteLine($"A legdrágább gyümölcs: {mostExpensive}");

double weightsLightest = fruits.Min(x =>  x.Weight);
Fruit leastHeavy = fruits.First(x => x.Weight == weightsLightest);
Console.WriteLine($"A legkönnyebb gyümölcs: {leastHeavy}");

Fruit[] GetFruits()
{
	Fruit[] fruits = new Fruit[NUMBER_OF_FRUITS];
	for (int i = 0; i < NUMBER_OF_FRUITS; i++)
	{
		string name = ExtendedConsole.ReadString("Add meg a gyümölcs nevét > ");
		double weight = ExtendedConsole.ReadDouble("Add meg hány kg van az adott gyümölcsből > ");
		double price = ExtendedConsole.ReadDouble("Add meg az árát (db) > ");

		Fruit fruit = new Fruit(name, weight, price);

		fruits[i] = fruit;
	}
	return fruits;
}

void WriteArrayToConsole(Fruit[] fruits)
{
	foreach (Fruit fruit in fruits)
	{
		Console.WriteLine($"{fruit.Name} teljes ára: {fruit.Price * fruit.Weight} Ft");
	}
}