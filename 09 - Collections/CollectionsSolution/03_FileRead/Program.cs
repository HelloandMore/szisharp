//A roplabda.txt állományban az adatok a következő módón vannak tárolva:
//Név,
//Magasság,
//Poszt,
//Nemzetiség,
//Csapat,
//Ország (ahol a csapat játszik)


//1 - Írjuk ki a képernyőre az összadatot

using System.Diagnostics;
string path = Path.Combine("../../../source/");
List<string> volleyball = new List<string>();
using (StreamReader sr = new StreamReader(path + ".adatok.txt"))
{
	while (!sr.EndOfStream)
	{
		volleyball.Add(sr.ReadLine());
	}
}
foreach (var i in volleyball)
{
	Console.WriteLine(i);
}

var players = new List<string[]>();
foreach (var i in volleyball)
{
	players.Add(i.Split('\t'));
}

//2 - Keressük ki az ütő játékosokat az utok.txt állömányba

var hitters = volleyball.Where(x => x.Split('\t')[2].ToLower() == "ütő");
using (StreamWriter sw = new StreamWriter(path + "utok.txt"))
{
	sw.WriteLine("Ütő játékosok:\n");
	foreach (var i in hitters)
	{
		sw.WriteLine(i);
	}
}


//3 - A csapattagok.txt állományba mentsük a csapatokat és a hozzájuk tartozó játékosokat
//    a következő formában:
//  Telekom Baku: Yelizaveta Mammadova, Yekaterina Gamova,
var teams = volleyball.GroupBy(x => x.Split('\t')[4])
					  .Select(x => new 
					  {
						  Team = x.Key, 
						  Players = x.Select(y => y.Split('\t')[0]) 
					  });

using (StreamWriter sw = new StreamWriter(path + "csapattagok.txt"))
{
	sw.WriteLine("Csapatok és játékosok:\n");
	foreach (var i in teams)
	{
		sw.WriteLine(i.Team + ": " + string.Join(", ", i.Players));
	}
	sw.WriteLine("\n");
}


//4 - Rendezzük a játékosokat magasság szerint növekvő sorrendbe és a 
//    magaslatok.txt állományba mentsük el.

var sorted = players.OrderBy(x => int.Parse(x[1]));
using (StreamWriter sw = new StreamWriter(path + "magaslatok.txt"))
{
	sw.WriteLine("Játékosok magasság szerint növekvő sorrendben:\n");
	foreach (var i in sorted)
	{
		sw.WriteLine(i[0] + " " + i[1]);
	}
}
//5 - Mutassuk be a nemzetisegek.txt állományba, hogy mely nemzetiségek képviseltetik
//    magukat a röplabdavilágban mint játékosok és milyen számban.

var nemzetisegek = new Dictionary<string, int>();
foreach (var i in volleyball)
{
	string[] adat = i.Split('\t');
	if (nemzetisegek.ContainsKey(adat[3]))
	{
		nemzetisegek[adat[3]]++;
	}
	else
	{
		nemzetisegek.Add(adat[3], 1);
	}
}
using (StreamWriter sw = new StreamWriter(path + "nemzetisegek.txt"))
{
	sw.WriteLine("Nemzetiségek és a játékosok száma:\n");
	foreach (var i in nemzetisegek)
	{
		sw.WriteLine(i.Key + ": " + i.Value);
	}
}
//6 - atlagnalmagasabbak.txt állományba keressük azon játékosok nevét és magasságát
//    akik magasabbak mint az „adatbázisban” szereplő játékosok átlagos magasságánál.


var averageHeight = players.Average(x => int.Parse(x[1]));
using (StreamWriter sw = new StreamWriter(path + "atlagnalmagasabbak.txt"))
{
	sw.WriteLine($"Átlagmagasságnál ({averageHeight}) magasabb játékosok:\n");
	foreach (var i in players)
	{
		if (int.Parse(i[1]) > averageHeight)
		{
			sw.WriteLine(i[0] + " " + i[1]);
		}
	}
}
//7 - Állítsa növekvő sorrendbe a posztok szerint a játékosok összmagasságát.
//    A posztokat és az összmagasságokat írja a képernyőre.

var sortedByPos = players.OrderBy(x => x[2]).GroupBy(x => x[2])
							.Select(x => new
							{
								Pos = x.Key,
								TotalHeight = x.Sum(y => int.Parse(y[1]))
							});
foreach (var i in sortedByPos)
{
	Console.WriteLine($"{i.Pos}: {i.TotalHeight}");
}


//8 - Egy szöveges állományba, „alacsonyak.txt” keresse ki a játékosok átlagmagasságától
//    alacsonyabb játékosokat. Az állomány tartalmazza a játékosok nevét,
//	magasságát és hogy mennyivel alacsonyabbak az átlagnál, 2 tizedes pontossággal.


using (StreamWriter sw = new StreamWriter(path + "alacsonyak.txt"))
{
	sw.WriteLine($"Átlagmagasságnál ({averageHeight}) alacsonyabb játékosok:\n");
	foreach (var i in players)
	{
		if (int.Parse(i[1]) < averageHeight)
		{
			sw.WriteLine(i[0] + " " + i[1] + " " + Math.Round(averageHeight - int.Parse(i[1]), 2));
		}
	}
}

//9 - Miután ezek lefutottak, megnyilnak a fájlok

Process.Start("notepad.exe", path + "utok.txt");
Process.Start("notepad.exe", path + "csapattagok.txt");
Process.Start("notepad.exe", path + "magaslatok.txt");
Process.Start("notepad.exe", path + "nemzetisegek.txt");
Process.Start("notepad.exe", path + "atlagnalmagasabbak.txt");
Process.Start("notepad.exe", path + "alacsonyak.txt");
Console.ReadKey();