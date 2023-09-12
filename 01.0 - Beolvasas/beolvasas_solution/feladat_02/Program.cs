Console.Write("Adja meg a nevét: ");
string name = Console.ReadLine();

Console.Write("Adja meg a születési évét: ");
int year = int.Parse(Console.ReadLine());

Console.WriteLine("{0} ön {1} évben született!", name, year);

Console.ReadKey();