Console.Write("Add meg a vizsgálandó számot > ");
int number = int.Parse(Console.ReadLine());
int remainder = number % 5;
int result = number / 5;

if (number %5 == 0)
{
    Console.WriteLine($"A szám OSZTHATÓ 5-tel (maradék nélkül) (eredmény: {result})");
}
else
{
    Console.WriteLine($"A szám NEM osztható 5-tel (Maradék: {remainder}) (eredmény: {result})");
}