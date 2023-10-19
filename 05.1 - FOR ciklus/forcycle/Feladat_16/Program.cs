bool isNum = false;
int startNum;
int endNum;
int sumOfEvenNum = 0;
int sumOfOddNum = 0;
double averageOfAll;

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

averageOfAll = (sumOfEvenNum + sumOfOddNum) / 2;

Console.WriteLine($"A páros, páratlan számok összegének átlaga: {averageOfAll}");