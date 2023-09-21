Console.WriteLine("Add meg az ellenállás két értékét!");
Console.Write("Első érték > ");
double resistance1 = double.Parse(Console.ReadLine());

Console.Write("Második érték > ");
double resistance2 = double.Parse(Console.ReadLine());

Console.Write("Add meg, hogy párhuzamosan (P) vagy sorosan (S) van bekötve > ");
string chosenResistance = Console.ReadLine();

double chosenResistanceResult = chosenResistance switch
{
	"P" => (resistance1 + resistance2) / (resistance1 * resistance2),
	"S" => resistance1 + resistance2,
	"p" => (resistance1 + resistance2) / (resistance1 * resistance2),
	"s" => resistance1 + resistance2,
	_ => (resistance1 + resistance2) / (resistance1 * resistance2)
};

Console.WriteLine($"\nAz eredő ellenállás értéke {chosenResistanceResult} ohm");