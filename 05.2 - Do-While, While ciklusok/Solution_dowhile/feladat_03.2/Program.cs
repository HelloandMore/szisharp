Random rnd = new Random();
int life = 5;
int random = rnd.Next(0, 10);
int number = 0;
bool isNumber = false;

while (!isNumber && number <= 0 && number >= 9 || number != random && life > 0)
{
    life--;

    Console.Write("Kérek egy számot: ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, out number);

    if (!isNumber)
    {
        Console.WriteLine("Nem számot adott meg");
    }
    else if (number < 0 || number > 9)
    {
        Console.WriteLine("Tartományon kívüli számot adott meg");
    }
}



if (life >= 0 && random == number)
{
    Console.WriteLine($"Gratulálok, kitalálta a számot {random}, és ennyi élete maradt: {life}");
}
else
{
    Console.WriteLine("Elfogyott az élete");

}