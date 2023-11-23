using IOLibrary;
using System.Transactions;

const double USD = 0.8;
const double JPY = 0.75;
const double CHF = 0.55;

int huf = ExtendedConsole.ReadInteger("Add meg a pénzösszeget HUF-ban > ", int.MaxValue, 0);
double eur = (double)huf / 400;
Currency currency = GetCurrency();

double convertedValue = currency switch
{
	Currency.USD => eur / USD,
	Currency.CHF => eur / CHF,
	Currency.JPY => eur / JPY,
};

Console.WriteLine($"{huf} HUF = {eur} EUR");
Console.WriteLine();

Currency GetCurrency()
{
	bool isCurrency = false;

	do
	{
		string input = ExtendedConsole.ReadString("Add meg a célvalutát (USD, JPY, CHF) > ");
		isCurrency = Enum.TryParse<Currency>(input, true, out currency);
	} while (!isCurrency);
	return currency;
}