/* Program, mely megkérdezi a felhasználó nevét és születési évét */

Console.Write("Hogy hívnak??!? > ");
string name = ExtendedConsole.ReadString();

Console.Write("Mikor születtél? > ");
int birthYear = ExtendedConsole.ReadInteger("Mikor születtél? > ", DateTime.Now.Year);

int calculateAge(int birthYear) => DateTime.Now.Year - birthYear;
int age = calculateAge(birthYear);

Console.WriteLine($"{name}, ön az idén {age} éves");