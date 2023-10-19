bool isNum = false;
int startNum;
int endNum;
int sumOfDevisibleWith5 = 0;
int sumOfDevisibleWith7 = 0;

do
{
	Console.Write("Kérek egy számot: ");
	string input = Console.ReadLine();
	isNum = int.TryParse(input, out startNum);
} while (!isNum);

do
{
	Console.Write("Most kérek egy számot, ami nem egyezik meg a másik számmal: ");
	string input = Console.ReadLine();
	isNum = int.TryParse(input, out endNum);
} while (!isNum || endNum == startNum);

if (startNum < endNum)
{
	for (int i = startNum; i <= endNum; i++)
	{
		if (i % 5 == 0)
		{
			sumOfDevisibleWith5 += i;
		}
		else if (i % 7 == 0)
		{
			sumOfDevisibleWith7 += i;
		}
	}
}
else if (endNum < startNum)
{
	for (int i = startNum; i >= endNum; i--)
	{
		if (i % 5 == 0)
		{
			sumOfDevisibleWith5 += i;
		}
		else if (i % 7 == 0)
		{
			sumOfDevisibleWith7 += i;
		}
	}
}

Console.WriteLine($"Az öttel osztható számok összege: {sumOfDevisibleWith5}\nA héttel osztható számok összege: {sumOfDevisibleWith7}");

if (sumOfDevisibleWith5 > sumOfDevisibleWith7)
{
	Console.WriteLine("\nAz öttel osztható számok összege a nagyobb!!!!");
}
else if (sumOfDevisibleWith7 > sumOfDevisibleWith5)
{
	Console.WriteLine("\nA héttel osztható számok összege a nagyobb!!!");
}
else
{
	Console.WriteLine("\n Ugyanannyi az öttel osztható és a héttel osztható számok összege!!!");
}