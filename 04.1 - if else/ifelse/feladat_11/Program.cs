Console.Write("Kérem a vizsgálandó számot > ");
int number = int.Parse(Console.ReadLine());

if (number % 2 != 0)
{
    Console.Write("A szám páratlan, ");
}
else if (number % 2 == 0)
{
    Console.Write("A szám páros, ");
}

if (number > 0)
{
    Console.Write("pozitív, ");
}
else if (number < 0)
{
    Console.Write("negatív, ");
}
else if (number == 0)
{
    Console.Write("nullával egyenlő, ");
}

if (number % 5 != 0)
{
    Console.Write("és NEM osztható öttel!");
}
else if (number % 5 == 0)
{
    Console.Write("és OSZTHATÓ öttel!");
}