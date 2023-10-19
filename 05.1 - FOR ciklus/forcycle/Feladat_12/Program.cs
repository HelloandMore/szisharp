bool isNum = false;
int startNum;
int endNum;
int devisibleWithThree = 0;

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
		if (i%3 == 0)
		{
			devisibleWithThree++;
		}
	}
}
else if (endNum < startNum)
{
	for (int i = startNum; i >= endNum; i--)
	{
		if (i%3 == 0)
		{
			devisibleWithThree++;
		}
	}
}

Console.WriteLine($"A két szám intervallumában {devisibleWithThree} szám osztható 3-mal");