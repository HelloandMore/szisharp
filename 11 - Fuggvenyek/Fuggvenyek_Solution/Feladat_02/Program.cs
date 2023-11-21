double celsius = ExtendedConsole.ReadDouble("Add meg a hőmérsékletet Celsiusban > ");

char unit;
do
{
	Console.Write("Milyen mértékegységbe akarod átváltani? (F - Fahrenheit, K - Kelvin) > ");
	unit = Console.ReadKey().KeyChar;
	unit = char.ToUpper(unit);
}
while (unit != 'F' && unit != 'K');

double convertedResult = unit == 'K' ? MathFunctions.CelsiusToKelvin(celsius) : MathFunctions.CelsiusToFahrenheit(celsius);

Console.WriteLine($"Az átváltott hőmérséklet: {convertedResult} {unit}");