int number = 0;
bool isNumber = false;

while (!isNumber || (number < 100 || number > 999))
{
    Console.Write("Kérek egy 3 jegyű számot:");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, out number);
    number = Math.Abs(number);

}


if (number % 7 == 0)
{
    Console.WriteLine("A szám osztható 7-tel");
}
else
{
    Console.WriteLine("A szám nem osztható 7-tel");
}