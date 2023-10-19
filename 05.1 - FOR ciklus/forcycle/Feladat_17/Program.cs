bool isNum = false;
int startNum;
int endNum;
int sumOfAllNum = 0;
int countOfNums = 0;
double average;

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
		sumOfAllNum += i;
		countOfNums++;
	}
}
else if (endNum < startNum)
{
	for (int i = startNum; i >= endNum; i--)
	{
		sumOfAllNum += i;
		countOfNums++;
	}
}

average = (double)sumOfAllNum / countOfNums;

Console.WriteLine($"A számok összegének átlaga: {average}");