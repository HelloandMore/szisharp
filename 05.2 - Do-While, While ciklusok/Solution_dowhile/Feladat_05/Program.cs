using System.Globalization;

int number;
int sum = 0;
int numofInputs = 0;
int setSum;
bool isNumber;

do
{
    Console.WriteLine("Melyik számod szeretnéd elérni kisebb számokkal (min. 100)? > ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, new CultureInfo("en-US"), out setSum);

    if (!isNumber)
    {
        Console.WriteLine("A bemenet nem szám");
    }
} while (!isNumber || setSum < 100);

do
{
	numofInputs++;
	Console.WriteLine($"A számok összege: {sum}");
	Console.WriteLine($"Írd egészen addig a számokat, míg azok összege el nem éri a megadott számot {setSum}!");
	Console.Write($"{numofInputs}. szám > ");
	number = int.Parse(Console.ReadLine());
	sum += number;
} while (sum < setSum);

Console.WriteLine("\nKecskesajt");