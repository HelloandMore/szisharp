using IOLibrary;

Player[] players = GetPlayers();
Console.Clear();

// játékosok
Console.WriteLine("Játékosok a csapatban: ");
WritePlayerNamesandGoals(players);

double averageAmountofGoals = players.Average(x => x.goalNumber);

Player[] playersBelowAvr = players.Where(x => x.goalNumber < averageAmountofGoals).ToArray();

// átlag alatti játékosok
Console.WriteLine("\nJátékosok NEVE, akik átlag ALATT teljesítenek: ");
WritePlayerNamesandGoals(playersBelowAvr);

// átlag feletti játékosok
int aboveAvrPlayers = players.Count(x => x.goalNumber > averageAmountofGoals);
Console.WriteLine($"\nJátékosok SZÁMA, akik átlag FELETT teljesítenek: {aboveAvrPlayers}");

// legjobban teljesítő játékos
Console.WriteLine($"\nLegjobban teljesítő játékos: {BestPerforming(players)}");


Player[] GetPlayers()
{
    Player[] player = new Player[9];

    for (int i = 0; i < 9; i++)
    {
        string name = ExtendedConsole.ReadString($"\n{i+1}. játékos neve > ");
        int goal = ExtendedConsole.ReadInteger($"{i+1}. játékos góljainak száma > ", int.MaxValue, 0);
        player[i] = new Player(name, goal);
    }
    return player;
}

void WritePlayerNamesandGoals(Player[] players)
{
	foreach (var player in players)
	{
        Console.WriteLine(player);
    }
}

Player BestPerforming(Player[] players)
{
    int maxGoal = players.Max(x => x.goalNumber);
    Player playerMvp = players.First(x => x.goalNumber == maxGoal);
    return playerMvp;
}