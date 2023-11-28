/* A program bekér egy dolgozat pontszámot (x) a felhasználótól és kiír egy
érdemjegyet az alábbiak szerint! : 
1: x<50; 2: 50<=x<60; 3: 60<=x<70; 4: 70<=x<85; 5: x>=85. */

using IOLibrary;

double point;

point = ExtendedConsole.ReadDouble("Add meg a dolgozatban elért pontszámod > ");

double gradeCalculator(double point)
{
	int returningValue;

	double percent = point;

	if (percent < 50)
	{
		returningValue = 1;
	}
	else if (percent >= 50 && percent < 60)
	{
		returningValue = 2;
	}
	else if (percent >= 60 && percent < 70)
	{
		returningValue = 3;
	}
	else if (percent >= 70 && percent < 85)
	{
		returningValue = 4;
	}
	else if (percent >= 85)
	{
		returningValue = 5;
	}
	else
	{
		returningValue = 0;
	}
	return returningValue;
}

Console.WriteLine($"A dolgozatra kapott jegyed a következő: {gradeCalculator(point)}");