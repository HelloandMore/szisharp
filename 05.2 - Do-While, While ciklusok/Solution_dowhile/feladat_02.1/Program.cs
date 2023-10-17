string name = string.Empty;

do
{
    Console.Write("Kérem adja meg a nevét: ");
    name = Console.ReadLine().Trim();
}
while (name.Length < 2);

Console.WriteLine($"Üdvözlöm {name}");
