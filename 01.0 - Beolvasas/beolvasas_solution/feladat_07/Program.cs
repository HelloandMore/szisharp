Console.Write("Add meg az autó márkáját: ");
string carBrand = Console.ReadLine();

Console.Write("Add meg az autó modelljét: ");
int carModel  = int.Parse(Console.ReadLine());

Console.Write("Add meg az autó típusát: ");
string carType = Console.ReadLine();

Console.Write("Add meg hogy hány köbcentis motorja van az autónak: ");
double cubicCM = double.Parse(Console.ReadLine());

Console.Write("Add meg a megjelenési évét az autónak: ");
int releaseYear = int.Parse(Console.ReadLine());

Console.WriteLine($"Márka: {carBrand}\r\nModell: {carModel}\r\nTípus: {carType}\r\nKöbcenti: {cubicCM}\r\nMegjelenési év: {releaseYear}");