using System.Globalization;

int age;
bool isNumber;
string ageGroup = "";

do
{
	Console.WriteLine("Életkor??!? (max. 100) > ");
	string input = Console.ReadLine();

	isNumber = int.TryParse(input, new CultureInfo("en-US"), out age);

	if (!isNumber)
	{
		Console.WriteLine("A bemenet nem szám");
	}
} while (!isNumber || age < 0 || age > 99);

if (age >=0 && age <=6)
{
	ageGroup = "gyerek";
}
else if (age >= 7 & age <=18)
{
	ageGroup = "iskolás";
}
else if (age >= 19 & age <= 65)
{
	ageGroup = "dolgozó";
}
else if (age >= 66)
{
	ageGroup = "nyugdíjas";
}

Console.WriteLine($"\nKorosztály: {ageGroup}");