using IOLibrary;

double propertyWidth = ExtendedConsole.ReadDouble("Add meg a telek szélességét > ");
double propertyLength = ExtendedConsole.ReadDouble("Add meg a telek hosszát > ");

double propertyArea = propertyLength * propertyWidth;

double propertyTax = propertyWidth < 20 && propertyLength < 30 ? CalculateTax(propertyArea) * 0.75 : CalculateTax(propertyArea);

double CalculateTax(double propertyArea) => propertyArea * 1000;

Console.WriteLine($"A teljes adó mértéke: {CalculateTax}");