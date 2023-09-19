Console.Write("Add meg az első számot > ");
int numberOne = int.Parse(Console.ReadLine());

Console.Write("Add meg a második számot > ");
int numberTwo = int.Parse(Console.ReadLine());

if (numberOne < numberTwo)
{
    Console.WriteLine($"Számok növekvő sorrendben: {numberOne} {numberTwo}");
}
else if (numberTwo < numberOne)
{
    Console.WriteLine($"Számok növekvő sorrendben: {numberTwo} {numberOne}");
}
else
{
	Console.WriteLine($"Számok egyenlőek, vagy helytelenek");
}