bool isNumber;
int stepAmount;


do
{
	Console.Write("Add meg a lépésközt> ");
	string input = Console.ReadLine();

	isNumber = int.TryParse(input, out stepAmount);
}
while (!isNumber || stepAmount < 1);

Console.Clear();

for (int i = 0; i <= stepAmount * 2; i += 2)
{
	for (int j = i / 2; j < stepAmount - 1; j++)
	{
		Console.Write("   ");
	}
	for (int k = 1; k <= i; k++)
	{
		Console.Write($"{k}".PadRight(3, ' '));
	}
	Console.WriteLine();
}