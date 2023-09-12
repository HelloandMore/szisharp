Console.Write("Add meg a neved > ");
string name = Console.ReadLine();

Console.WriteLine("Nyomj meg egy billentyűt ");
char key = Console.ReadKey().KeyChar;

Console.WriteLine($"{name} ön a/az {key} billentyűt nyomta meg!");
Console.ReadKey();