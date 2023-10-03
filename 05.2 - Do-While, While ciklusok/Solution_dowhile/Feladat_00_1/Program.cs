/* 
1. felhasználótól kérünk egy számot 1-9 között
 */

using System.Globalization;

int number = 0;
bool isNumber = false;

while (!isNumber || number < 0 || number > 9)
{
	Console.Write("Adj meg egy számot, ami lehetőleg 1-9 között szerepel > ");
	string input = Console.ReadLine();
	/*
		Az input változó értékét (string) megpróbálja a TryParse számmá alakítani.
		Ha sikerül, az isNumber értéke True lesz, és a number változóban eltárolódik a beírt szám (string) szám értékként.
		Ha nem sikerült, az isNumber értéke false lesz, és a number változó értéke nem változik, megmarad deklaráláskor adott értékén (0)
		new CultureInfo("en-US") jelentése az, hogy amerikai angol környezetben szerenénk használni az átalakítást (majd), akkor a tizedes
		jelekként megadott pontot a vessző helyett is tudja majd kezelni.
	*/

	isNumber = int.TryParse(input, new CultureInfo("en-US"), out number);

	if (!isNumber)
	{
		Console.WriteLine("Nem számott adott meg!");
	}
	else if (number < 0 || number > 9)
	{
		Console.WriteLine("A megadott érték nincs a tartományban");
	}

}

Console.WriteLine($"A beolvasott szám: {number}");

Console.ReadKey();