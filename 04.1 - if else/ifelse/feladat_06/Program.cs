Console.Write("Add meg az első számot > ");
int numberOne = int.Parse(Console.ReadLine());

Console.Write("Add meg a második számot > ");
int numberTwo = int.Parse(Console.ReadLine());

Console.Write("Add meg a harmadik számot > ");
int numberThree = int.Parse(Console.ReadLine());

if (numberOne < numberTwo && numberTwo < numberThree)
{
	Console.WriteLine($"Számok növekvő sorrendben: {numberOne} {numberTwo} {numberThree}");
}
else if (numberThree < numberTwo && numberTwo < numberOne)
{
	Console.WriteLine($"Számok növekvő sorrendben: {numberThree} {numberTwo} {numberOne}");
}
else if (numberOne < numberThree && numberThree < numberTwo)
{
	Console.WriteLine($"Számok növekvő sorrendben: {numberOne} {numberThree} {numberTwo}");
}
else if (numberTwo < numberThree && numberThree < numberOne)
{
	Console.WriteLine($"Számok növekvő sorrendben: {numberTwo} {numberThree} {numberOne}");
}
else if (numberTwo < numberOne && numberOne < numberThree)
{
	Console.WriteLine($"Számok növekvő sorrendben: {numberTwo} {numberOne} {numberThree}");
}
else if (numberThree < numberOne && numberOne < numberTwo)
{
	Console.WriteLine($"Számok növekvő sorrendben: {numberThree} {numberOne} {numberTwo}");
}
else
{
	Console.WriteLine($"Számok egyenlőek, vagy helytelenek");
}