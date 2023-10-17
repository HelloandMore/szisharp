using System.Globalization;

int number = 0;
bool isNumber = false;
while (!isNumber || (number < 0 || number > 9)) 
{
    Console.Write("Please enter a number between 0 and 9: ");
    string input = Console.ReadLine();

    /*
     az input változó értékét (string) megpróbálja a TryParse számmá alakítani, ha sikerül az Isnumber értéke true élesz a változóban eltárolódik
    a beírt szám (string) szám értékként . Ha nem sikerült az isNumber értéke false lesz és a number változó értéke nem változik, megmarad a dekla-
    ráláskor adott értékén(0). new CultureInfo("en-US") jelentése az, hogy amerikai angol környezetben szeretnénk használni az átalakítást, azaz, ha
    tizedes számot (double, float) szeretnénk átalakítani (majd), akkor a tizedes jeleket megadott pontot a vessző helyett is tudja majd kezelni 
    (angol nyelvi környezetben a tizedes jele a pont, magyar nyelvi környezetben a tizedes jele a vessző, mivel a Windows magyar nyelvű, ezért elvárná
    tőlünk, hogy a tizedes számot vesszővel írjuk. Ezt a tulajdonságot orvosolja a new CultureInfo("en-US")) */

    isNumber = int.TryParse(input, new CultureInfo("en-US"), out number);
    if (!isNumber)
    {
        Console.WriteLine("Nem számot adott meg");
    }
    else if (number < 0 || number > 9)
    {
        Console.WriteLine("A megadott szám nincs a tartományban");
    }
}


Console.WriteLine("A szám a megadott tartományban van");