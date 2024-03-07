// 2.
using IOLibrary;

List<Player> players = await FileService.ReadFromFileAsync("balkezesek.csv");

// 3.
int amountOfPlayer = players.Count;
Console.WriteLine($"Játékosok száma a listában: {amountOfPlayer}");

// 4.
List<Player> playersLastTime = players.Where(p => p.LastTime.Year == 1999 && p.LastTime.Month == 10).ToList();
Console.WriteLine("\nJátékosok, akik utoljára 1999 októberében léptek pályára: ");
ExtendedConsole.WriteArrayToConsole(playersLastTime.Select(p => $"{p.Name}, {p.Height * 2.54:F1} cm").ToArray());

// 5.
int randomInputYear = 0;
while (randomInputYear > 1999 || randomInputYear < 1990)
{
	randomInputYear = ExtendedConsole.ReadInteger("\nAdj meg egy évszámot 1990 és 1999 között > ", 1999, 1990);
}

// 6.
List<Player> playersRandomYear = players.Where(p => p.FirstTime.Year == randomInputYear).ToList();
double averageWeight = (double)playersRandomYear.Average(p => p.Weight);
Console.WriteLine($"\n{randomInputYear} évben pályára lépők átlagsúlya: {averageWeight:F2} font");