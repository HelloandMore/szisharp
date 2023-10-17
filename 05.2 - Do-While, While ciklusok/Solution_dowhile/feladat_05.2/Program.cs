int limit = 0;
int number = 0;
int result = 0;
int amount = 0;
bool isNumber = false;
bool isLimit = false;

while (!isLimit || limit < 100) 
{
    Console.Write("Kérek egy határértéket(minimum 100): ");
    string input = Console.ReadLine();

    isLimit = int.TryParse(input, out limit);
}

while (!isNumber || result < limit)
{
    amount++;

    Console.Write("Kérek egy számot: ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, out number);

    result += number;

    Console.WriteLine($"A jelenlegi összeg {result}");
}

Console.WriteLine($"A limitet {amount} leütésből sikerült elérni.");