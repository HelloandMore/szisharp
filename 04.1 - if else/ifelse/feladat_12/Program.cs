Console.Write("Add meg a vizsgálandó számot > ");
int number = int.Parse(Console.ReadLine());

if (number <= 20 && number >= 10)
{
    Console.WriteLine("A szám 10 és 20 között található!");
}
else if (number <= -10 && number >= -20) {
    Console.WriteLine("A szám -20 és -10 között található!");
}
else
{
    Console.WriteLine("A szám sem 10 és 20 között, sem -20 és -10 között nem található!");
}