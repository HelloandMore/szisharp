﻿bool isNum = false;
int startNum;
int endNum;
int numOfDevisibleWithThree = 0;

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
	if (startNum%2 == 0)
		startNum++;
	for (int i = startNum; i <= endNum; i+=2)
	{
		if (i % 3 == 0)
		{
			numOfDevisibleWithThree++;
		}
	}
}
else if (endNum < startNum)
{
	if (endNum % 2 == 0)
		startNum--;
	for (int i = startNum; i >= endNum; i-=2)
	{
		if (i % 3 == 0)
		{
			numOfDevisibleWithThree++;
		}
	}
}

Console.WriteLine($"A két szám intervallumában {numOfDevisibleWithThree} páratlan szám osztható 3-mal");