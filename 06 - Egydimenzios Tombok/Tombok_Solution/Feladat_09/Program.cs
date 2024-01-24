using IOLibrary;

const int NUMBER_OF_PLAYERS = 2;


Player[] players = GetPlayers();

double averageHeight = players.Average(player => player.Height);

Console.WriteLine("\nÁtlagnál alacsonyabb játékos(ok): ");
Player[] shortPlayers = players.Where(player => player.Height < averageHeight).ToArray();
ExtendedConsole.WriteArrayToConsole(shortPlayers);

double tallPlayers = 1 - (shortPlayers.Length / (double)NUMBER_OF_PLAYERS);
Console.WriteLine($"\nÁtlagnál magasabb játékosok százaléka: {tallPlayers*100:F2}%");

int totalPoints = players.Sum(player => player.sumOfPoints);
Console.WriteLine($"\nA csapat ebben a szezonban összesen {totalPoints} pontot szezett");

int leastPoints = players.Min(player => player.sumOfPoints);
Player LVP = players.First(player => player.sumOfPoints == leastPoints);
Console.WriteLine($"\nA legkevesebb pontot {LVP} szerezte");

int mostPoints = players.Max(player => player.sumOfPoints);
Player MVP = players.First(player => player.sumOfPoints == mostPoints);
Console.WriteLine($"\nA legtöbb pontot {MVP} szerezte");

int tallest = players.Max(player => player.Height);
Player tallestPlayer = players.First(player => player.Height == tallest);

int shortest = players.Min(player => player.Height);
Player shortestPlayer = players.First(player => player.Height == shortest);

TallSmall tallSmall = new TallSmall(tallestPlayer, shortestPlayer);
Console.WriteLine(tallSmall);

Player[] GetPlayers()
{
	Player[] players = new Player[NUMBER_OF_PLAYERS];

	for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
	{
		string name = ExtendedConsole.ReadString($"\nAdd meg a(z) {i + 1}. játékos nevét > ");
		int height = ExtendedConsole.ReadInteger($"Add meg {name} magasságát > ", int.MaxValue, 0);
		int sumOfPoints = ExtendedConsole.ReadInteger($"Add meg mennyi pontot szerzett {name} > ", int.MaxValue, 0);

		players[i] = new Player(name, height, sumOfPoints);
	}
	return players;
}