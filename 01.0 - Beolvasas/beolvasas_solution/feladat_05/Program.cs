Console.Write("Add meg a kedvenc együttesed nevét: ");
string bandName = Console.ReadLine();

Console.Write("Add meg melyik a kedvenc számuk tőlük: ");
string favMusic = Console.ReadLine();

Console.Write("Milyen hosszú ez a számuk? ");
int musicLength = int.Parse(Console.ReadLine());

Console.WriteLine($"Az ön kedvenc együttesének {bandName} a legjobb zeneszáma {favMusic} melynek hossza {musicLength} perc");