Console.Write("Add meg a kedvenc filmed címét: ");
string movieName = Console.ReadLine();

Console.Write("Add meg a film megjelenési évét: ");
int releaseDate = int.Parse(Console.ReadLine());

Console.Write("Add meg a főszereplő nevét: ");
string mainCharatersName = Console.ReadLine();

Console.Write("Add meg a rendező nevét: ");
string directorsName = Console.ReadLine();

Console.WriteLine($"{releaseDate}-ban/ben {directorsName} rendezésében megjelent a/az {movieName} című film {mainCharatersName} főszereplésével!");