Console.Write("\n1 – Coca Cola\n2 – Pepsi\n3 – Fanta\n4 – Sprite\nMelyiket kéred a következők közül? > ");
int numberofChoice = int.Parse(Console.ReadLine());

string nameofChoice = numberofChoice switch
{
	1 => "Megkaptad a Coca Colád",
	2 => "Megkaptad a Pepsid",
	3 => "Megkaptad a Fantád",
	4 => "Megkaptad a Spriteot",
	_ => "A választott számhoz nincs üdítő társítva",
};

Console.WriteLine($"\n{nameofChoice}");