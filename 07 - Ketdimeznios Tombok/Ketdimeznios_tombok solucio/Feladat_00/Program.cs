int sor = 4; //sorok szama
int oszlop = 3; //oszlopok szama
int[,] matrix = new int[sor, oszlop];

Random rnd = new Random();

for (int n = 0; n < sor; n++)
{
	for (int m = 0; m < oszlop; m++)
	{
		Console.Write($"[{n},{m}] = {matrix[n, m]}\t");
	}
	Console.WriteLine();
}

Console.WriteLine("Egy n sort és m oszlopot tartalmazó tömb kiírása");
Thread.Sleep(10000);
Console.Clear();

int sor2 = 4; //sorok száma
int oszlop2 = 3; //oszlopok száma
int[,] matrix2 = new int[sor2, oszlop2];

for (int n = 0; n < sor2; n++)
{
	for (int m = 0; m < oszlop2; m++)
	{
		Console.Write($"[{n},{m}] = ");
	matrix2[n, m] = int.Parse(Console.ReadLine());
	}
Console.WriteLine();
};

Console.WriteLine("Egy n sort és m oszlopot tartalmazó tömb kiírása");
Thread.Sleep(4000);