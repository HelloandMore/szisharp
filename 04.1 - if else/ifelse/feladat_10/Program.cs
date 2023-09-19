Console.Write("Add meg a vizsgálandó számot > ");
int number = int.Parse(Console.ReadLine());

if (number % 2 == 0 && number % 3 == 0)
{
    Console.WriteLine("ZIZI");
}
else if (number % 2 == 0)
{
    Console.WriteLine("BIZ");
}
else if (number % 3 == 0)
{
    Console.WriteLine("BAZ");
}
else if (number % 2 != 0 && number % 3 != 0)
{
    Console.WriteLine("A szám se 2-vel, se 3-mal nem osztható");
}