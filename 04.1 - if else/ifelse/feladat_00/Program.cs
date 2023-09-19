Console.Write("Add meg a vizsgálandó számot > ");

int number = int.Parse(Console.ReadLine());

if (number > 0)
{
	Console.WriteLine("A szám nagyobb, mint 0");
}
else if(number < 0)
{
	Console.WriteLine("A szám kisebb, mint 0");
}
else if(number == 0)
{
    Console.WriteLine("A szám nullával egyenlő");
}