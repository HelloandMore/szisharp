Console.Write("Adja meg a nevét: ");
string name = Console.ReadLine();

Console.Write("Adja meg a magasságát: ");
double height = double.Parse(Console.ReadLine());

Console.WriteLine("{0} az ön magassága {1} cm", name, height);
Console.ReadKey();