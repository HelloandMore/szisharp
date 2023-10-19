﻿bool isNum = false;
int startNum;
int endNum;
int sumOfAll = 0;
int multiplication = 1;

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
	startNum++;
	for (int i = startNum; i <= endNum; i+=2)
	{
		multiplication *= i;	}
}
else if (endNum < startNum)
{
	for (int i = startNum; i >= endNum; i-=2)
	{
		sumOfAll += i;
		Console.WriteLine(i);
	}
	for (int i = startNum; i <= endNum; i -= 2)
	{
		multiplication *= i;
	}
}

Console.WriteLine($"A számok összege: {sumOfAll}");
Console.WriteLine($"A számok szorzata: {multiplication}");