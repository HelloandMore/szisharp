Console.Write("Add meg a vizsgálandó számot > ");
int number = int.Parse(Console.ReadLine());

if (number >= 0 && number <= 9)
{
    Console.WriteLine("A szám EGYJEGYŰ");
}
else if (number >= 10 && number <= 99)
{
    Console.WriteLine("A szám KÉTJEGYŰ");
}
else if (number >= 100 && number <= 999)
{
    Console.WriteLine("A szám HÁROMJEGYŰ");
}
else
{
    Console.WriteLine("A szám NÉGY vagy többjegyű\nSajnos ez a kód csak eddig tudja megállapítani :(");
}