bool isNum = false;
int startNum;
int endNum;
int sumOfAll = 0;

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
		sumOfAll += i;
		Console.WriteLine(i);
	}
} else if (endNum < startNum)
{
	for (int i = startNum; i >= endNum; i--)
	{
		sumOfAll += i;
		Console.WriteLine(i);
	}
}

Console.WriteLine($"A számok összege: {sumOfAll}");