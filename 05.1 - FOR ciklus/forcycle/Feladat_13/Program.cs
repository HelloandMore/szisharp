bool isNum = false;
int startNum;
int endNum;
int sumOfEvenNum = 0;
int sumOfOddNum = 0;

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
		if(i%2 == 0)
		{
			sumOfEvenNum += i;
		} else if (i%2 != 0)
		{
			sumOfOddNum += i;
		}
	}
}
else if (endNum < startNum)
{
	for (int i = startNum; i >= endNum; i--)
	{
		if (i % 2 == 0)
		{
			sumOfEvenNum += i;
		}
		else if (i % 2 != 0)
		{
			sumOfOddNum += i;
		}
	}
}

Console.WriteLine($"A páros számok összege: {sumOfEvenNum}\nA páratlan számok összege: {sumOfOddNum}");

if (sumOfEvenNum > sumOfOddNum)
{
    Console.WriteLine("\nA páros számok összege a nagyobb!!!!");
}
else if (sumOfOddNum > sumOfEvenNum)
{
    Console.WriteLine("\nA páratlan számok összege a nagyobb!!!");
}
else
{
    Console.WriteLine("\n Ugyanannyi a páros és a páratlan számok összege!!!");
}