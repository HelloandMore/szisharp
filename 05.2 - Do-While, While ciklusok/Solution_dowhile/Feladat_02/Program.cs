/*
Program, ami bekéri a nevünket, majd köszönt (ez nagyjából a 438148x-adik ilyen)
 */

string name = string.Empty;

do
{
    Console.Write("Add meg a nevet > ");
    name = Console.ReadLine().Trim();
} while (name.Length < 2);

Console.WriteLine($"Üdvözlet {name}");

Console.ReadKey();