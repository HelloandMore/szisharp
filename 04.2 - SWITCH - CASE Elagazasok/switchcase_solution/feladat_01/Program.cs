Console.Write("Hányadik napja a hétnek? Írd le számmal > ");
int numberofDay = int.Parse(Console.ReadLine());

string nameofDay = numberofDay switch
{
	1 => "Hétfő",
	2 => "Kedd",
	3 => "Szerda",
	4 => "Csütörtök",
	5 => "Péntek",
	6 => "Szombat",
	7 => "Vasárnap",
	_ => "nem létezik",
};

Console.WriteLine($"A hét {numberofDay}. napja {nameofDay}");