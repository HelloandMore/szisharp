Console.Write("Add meg a vizsgálandó számot > ");
int number = int.Parse(Console.ReadLine());
int resultfor4 = number / 4;
int resultfor6 = number / 6;
int remainderFor4 = number % 4;
int remainderFor6 = number % 6;

if (number % 4 == 0 && number % 6 == 0)
{
    Console.WriteLine($"A szám OSZTHATÓ 4-gyel és 6-tal is\n4-gyel osztva ennyi: {resultfor4}\n6-tal osztva ennyi: {resultfor6}");
}
else if (number % 4 != 0 && number % 6 == 0)
{
    Console.WriteLine($"A szám CSAK 6-tal osztható maradék nélkül!\n6-tal osztva ennyi: {resultfor6}\n4-gyel osztva ennyi: {resultfor4} és a maradéka: {remainderFor4}");
}
else if (number % 6 != 0 && number % 4 == 0)
{
    Console.WriteLine($"A szám CSAK 4-gyel osztható maradék nélkül!\n4-gyel osztva ennyi: {resultfor4}\n6-tal osztva ennyi: {resultfor6} és a maradéka: {remainderFor6}");
}
else if (number % 6 != 0 && number % 4 != 0)
{
    Console.WriteLine($"A szám SEM 4-gyel SEM 6-tal NEM osztható maradék nélkül!\n4-gyel osztva: {resultfor4} és ennyi a maradéka: {remainderFor4}\n6-tal osztva: {resultfor6} és ennyi a maradéka: {remainderFor6}");
}
else
{
    Console.WriteLine("Valami hiba történt! Kérlek futtasd újra!");
}