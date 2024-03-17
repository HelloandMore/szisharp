// 2.
using IOLibrary;

List<Player> players = await FileService.ReadFromFileAsync("balkezesek.csv");

// 3.
int amountOfPlayer = players.Count;
//Console.WriteLine($"Játékosok száma a listában: {amountOfPlayer}");
Console.WriteLine($"3. feladat: {amountOfPlayer}");

// 4.
List<Player> playersLastTime = players.Where(p => p.LastTime.Year == 1999 && p.LastTime.Month == 10).ToList();
// Console.WriteLine("\nJátékosok, akik utoljára 1999 októberében léptek pályára: ");
Console.WriteLine("4. feladat: ");
ExtendedConsole.WriteArrayToConsole(playersLastTime.Select(p => $"{p.Name}, {p.Height * 2.54:F1} cm").ToArray());

// 5.
int randomInputYear = 0;
Console.WriteLine("\n5. feladat: ");
while (randomInputYear > 1999 || randomInputYear < 1990)
{
	// randomInputYear = ExtendedConsole.ReadInteger("\nAdj meg egy évszámot 1990 és 1999 között > ", 1999, 1990);
	randomInputYear = ExtendedConsole.ReadInteger("\nKérek egy 1990 és 1999 közötti évszámot! > ", 1999, 1990);
}

// 6.
List<Player> playersRandomYear = players.Where(p => p.FirstTime.Year == randomInputYear).ToList();
double averageWeight = (double)playersRandomYear.Average(p => p.Weight);
// Console.WriteLine($"\n{randomInputYear} évben pályára lépők átlagsúlya: {averageWeight:F2} font");
Console.WriteLine($"\n6. feladat: {averageWeight:F2}");