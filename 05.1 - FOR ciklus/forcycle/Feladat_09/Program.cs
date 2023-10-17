bool isNum = false;
int startNum;
int endNum;

do
{
	Console.Write("Kérek egy számot: ");
	string input = Console.ReadLine();
	isNum = int.TryParse(input, out startNum);
} while (!isNum);

do
{
	Console.Write("Most kérek egy számot, ami az előzőnél kisebb: ");
	string input = Console.ReadLine();
	isNum = int.TryParse(input, out endNum);
} while (!isNum || endNum > startNum);

if (startNum % 2 == 0)
{
	startNum--;
	for (int i = startNum; i >= endNum; i = i - 2)
	{
		Console.WriteLine(i);
	}
}
else if (endNum % 2 != 0)
{
	for (int i = startNum; i >= endNum; i = i - 2)
	{
		Console.WriteLine(i);
	}
}