using IOLibrary;
const int NUMBER_OF_PLAYERS = 5;

Player[] players = GetPlayers();

double averagePoints = players.Average(x => x.NumOfGoals);
int sumOfPoints = players.Sum(x => x.NumOfGoals);
int belowAverage = players.Count(x => x.NumOfGoals < averagePoints);

int mostPoints = players.Max(x => x.NumOfGoals);
Player bestPlayer = players.First(x => x.NumOfGoals == mostPoints);
Console.WriteLine($"\n\nA legtöbb ponttal rendelkező játékos: {bestPlayer}");

int leastPoints = players.Min(x => x.NumOfGoals);
Player worstPlayer = players.First(x => x.NumOfGoals == leastPoints);
Console.WriteLine($"A legkevesebb ponttal rendelkező játékos: {worstPlayer}");

Player[] aboveAverage = players.Where(x => x.NumOfGoals > averagePoints).ToArray();
Console.WriteLine("\n\nÁtlag felett teljesítő játékosok: ");
WriteArrayToConsole(aboveAverage);

Console.WriteLine($"Átlag alatt teljesítő játékosok száma: {belowAverage}");

Player[] GetPlayers()
{
	Player[] player = new Player[NUMBER_OF_PLAYERS];
	for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
	{
		string name = ExtendedConsole.ReadString($"\nAdd meg a(z) {i + 1}. játékos nevét > ");
		int numOfGoals = ExtendedConsole.ReadInteger($"Add meg hány pontja van a(z) {i + 1}. játékosnak > ", int.MaxValue, 0);

		player[i] = new Player(name, numOfGoals);
	}
	return player;
}

void WriteArrayToConsole(Player[] players)
{
	foreach (Player player in players)
	{
        Console.WriteLine($"{player.Name} {player.NumOfGoals} ponttal végzett");
    }
}