﻿bool isNumber;
int stepAmount;

do
{
	Console.Write("Add meg a lépésközt> ");
	string input = Console.ReadLine();
	isNumber = int.TryParse(input, out stepAmount);
}
while (!isNumber || stepAmount < 1);

Console.Clear();

for (int i = 0; i <= stepAmount; i++)
{
	for (int j = 1; j <= i; j++)
	{
		Console.Write($"{j}".PadRight(3, ' '));
	}
	Console.WriteLine();
}