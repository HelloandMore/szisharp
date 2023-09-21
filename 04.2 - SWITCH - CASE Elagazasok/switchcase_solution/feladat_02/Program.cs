Console.Write("Hányadik hónapja az évnek? Írd le számmal > ");
int numberofMonth = int.Parse(Console.ReadLine());

string nameofMonth = numberofMonth switch
{
	1 => "Január",
	2 => "Február",
	3 => "Március",
	4 => "Április",
	5 => "Május",
	6 => "Június",
	7 => "Július",
	8 => "Augusztus",
	9 => "Szeptember",
	10 => "Október",
	11 => "November",
	12 => "December",
	_ => "nem létezik",
};

Console.WriteLine($"Az év {numberofMonth}. hónapja {nameofMonth}");