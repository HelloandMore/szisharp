/* A program bekér egy dolgozat pontszámot (x) a felhasználótól és kiír egy
érdemjegyet az alábbiak szerint! : 
1: x<50; 2: 50<=x<60; 3: 60<=x<70; 4: 70<=x<85; 5: x>=85. */

using IOLibrary;

double point;

point = ExtendedConsole.ReadDouble("Add meg a dolgozatban elért pontszámod > ");

double gradeCalculator(double point)
{
	double percent = point;

	switch (percent)
	{
		case < 50:
			return 1;
		case < 60:
			return 2;
		case < 70:
			return 3;
		case < 85:
			return 4;
		default:
			return 5;
	}
}

Console.WriteLine($"A dolgozatra kapott jegyed a következő: {gradeCalculator(point)}");