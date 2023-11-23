using CustomLibrary;
using IOLibrary;

char unit;
string unitFull = string.Empty;
double convertedResult = 0;
double amountOfMoney = 0;
double euro = 0;

do
{
	amountOfMoney = ExtendedConsole.ReadDouble("Add meg az összeget HUF-ban > ");
} while (amountOfMoney < 0);

euro = amountOfMoney * 0.0026;

do
{
	Console.Write("Milyen pénznembe akarod átváltani? (U - Amerikai dollár, J - Japán jen, E - Európai euro, C -  Svájci frank) > ");
	unit = Console.ReadKey().KeyChar;
	unit = char.ToUpper(unit);
}
while (unit != 'U' && unit != 'J' && unit != 'E' && unit != 'C');

switch (unit)
{
	case 'U':
		convertedResult = amountOfMoney * 0.0029;
		unitFull = "Amerikai dollár";
		break;
	case 'J':
		convertedResult = amountOfMoney * 0.43;
		unitFull = "Japán jen";
		break;
	case 'E':
		convertedResult = amountOfMoney * 0.0026;
		unitFull = "Európai euro";
		break;
	case 'C':
		convertedResult = amountOfMoney * 0.0025;
		unitFull = "Svájci frank";
		break;
}

Console.WriteLine($"\nAz átváltott összeg: {convertedResult:F2} {unitFull}\nEz az összeg euróban: {euro}");
Console.ReadKey();