Console.Write("Add meg az első számot > ");
int numberOne = int.Parse(Console.ReadLine());

Console.Write("Add meg a második számot > ");
int numberTwo = int.Parse(Console.ReadLine());

int remainder1 = numberOne % numberTwo;
int remainder2 = numberTwo % numberOne;

if (numberOne % numberTwo == 0)
{
    Console.WriteLine("A két szám OSZTÓJA egymásnak");
}
else if (numberTwo % numberOne == 0)
{
	Console.WriteLine("A két szám OSZTÓJA egymásnak");
}
else if (numberOne % numberTwo != 0)
{
    Console.WriteLine($"A két szám NEM osztója egymásnak!\nEgymással osztva ezt a maradékot kapjuk: {remainder1} és {remainder2}");
}
else if (numberTwo % numberOne != 0)
{
	Console.WriteLine($"A két szám NEM osztója egymásnak!\nEgymással osztva ezt a maradékot kapjuk: {remainder1} és {remainder2}");
}