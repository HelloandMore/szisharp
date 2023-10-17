int number = 0;
bool isNumber = false;
int amount = 0;
int canBeSharedWith11 = 0;

while (!isNumber || (number < 1 || number > 99)) 
{
    Console.Write("Kérek egy kétjegyű pozitív számot: ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, out number);
}


for (int i = 0; i < number; i += 2)
{
    Console.Write($"{i}; ");
}

Console.WriteLine();

for (int i = 0; i < number; i++)
{
    if (i % 5 == 0)
    {
        amount += i;
    }

    if (i % 11 == 0)
    {
        canBeSharedWith11++;
    }
    if (i % 7 == 3)
    {
        Console.Write($"{i}; ");
    }
}

Console.WriteLine($"\nÖttel osztható számok összege: {amount}\n11-el osztható számok száma: {canBeSharedWith11} db");