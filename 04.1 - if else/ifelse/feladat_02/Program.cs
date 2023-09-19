Console.Write("Adj meg egy számot > ");
int number = int.Parse(Console.ReadLine());

if(number >= 0)
{
    Console.WriteLine("A megadott szám pozitív!");
}
else if(number < 0)
{
    Console.WriteLine("A megadott szám negatív!");
}