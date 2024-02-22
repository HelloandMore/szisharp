//A roplabda.txt állományban az adatok a következő módón vannak tárolva:
//Név,
//Magasság,
//Poszt,
//Nemzetiség,
//Csapat,
//Ország (ahol a csapat játszik)

//A feladatok megoldásához vegye igénybe a linq nyelvi elemeket.
//A feladatok megoldásához készítsen egy C# konzol alkalmazást, amely a következő feladatokat oldja meg:

//1 - Írjuk ki a képernyőre az össz adatot
string path = "../../../source/";
string[] lines = File.ReadAllLines(path + ".adatok.txt");
foreach (var line in lines)
{
	Console.WriteLine(line);
}
//2 - Keressük ki az ütő játékosokat, majd mentsük ki az utok.txt állományba
StreamWriter sw0 = new StreamWriter(path + "utok.txt");
foreach (var line2 in lines)
{
	string[] data = line2.Split('\t');
	if (data[2] == "ütő")
	{
		sw0.WriteLine(line2);
	}
}
sw0.Close();
//3 - A csapattagok.txt állományba mentsük a csapatokat és a hozzájuk tartozó játékosokat a következő formában: Csapat: Játékos1, Játékos2, Játékos3, …
Dictionary<string, List<string>> teamPlayers = new Dictionary<string, List<string>>();
foreach (var line3 in lines)
{
	string[] data2 = line3.Split('\t');
	if (teamPlayers.ContainsKey(data2[4]))
	{
		teamPlayers[data2[4]].Add(data2[0]);
	}
	else
	{
		teamPlayers.Add(data2[4], new List<string> { data2[0] });
	}
}
StreamWriter sw1 = new StreamWriter(path + "csapattagok.txt");
foreach (var teamPlayer in teamPlayers)
{
	sw1.Write(teamPlayer.Key + ": ");
	for (int i = 0; i < teamPlayer.Value.Count; i++)
	{
		sw1.Write(teamPlayer.Value[i]);
		if (i != teamPlayer.Value.Count - 1)
		{
			sw1.Write(", ");
		}
	}
	sw1.WriteLine();
}
sw1.Close();

//4 - Rendezzük a játékosokat magasság szerint növekvő sorrendbe és a magaslatok.txt állományba mentsük el
List<string> players = new List<string>();
foreach (var line4 in lines)
{
	players.Add(line4);
}

players.Sort((x, y) =>
{
	string[] data3 = x.Split('\t');
	string[] data4 = y.Split('\t');
	double height1 = Convert.ToDouble(data3[1]);
	double height2 = Convert.ToDouble(data4[1]);
	return height1.CompareTo(height2);
});

StreamWriter sw2 = new StreamWriter(path + "magaslatok.txt");
foreach (var player in players)
{
	string[] data5 = player.Split('\t');
	sw2.WriteLine(data5[0] + ": " + data5[1] + " cm");
}
sw2.Close();

//5 - Mutassuk be a nemzetisegek.txt állományba, hogy mely nemzetiségek képviseltetik magukat a röplabdavilágban mint játékosok és milyen számban.
Dictionary<string, int> nationality = new Dictionary<string, int>();
foreach (var line5 in lines)
{
	string[] data5 = line5.Split('\t');
	if (nationality.ContainsKey(data5[3]))
	{
		nationality[data5[3]]++;
	}
	else
	{
		nationality.Add(data5[3], 1);
	}
}
StreamWriter sw3 = new StreamWriter(path + "nemzetisegek.txt");
foreach (var nationalities in nationality)
{
	sw3.WriteLine(nationalities.Key + ": " + nationalities.Value);
}
sw3.Close();

//6 - atlagnalmagasabbak.txt állományba keressük azon játékosok nevét és magasságát akik magasabbak mint az „adatbázisban” szereplő játékosok átlagos magasságánál.
double averageHeight = 0;
foreach (var line6 in lines)
{
	string[] adatok6 = line6.Split('\t');
	averageHeight += Convert.ToDouble(adatok6[1]);
}
averageHeight /= lines.Length;
StreamWriter sw4 = new StreamWriter(path + "atlagnalmagasabbak.txt");
foreach (var line7 in lines)
{
	string[] adatok7 = line7.Split('\t');
	if (Convert.ToDouble(adatok7[1]) > averageHeight)
	{
		sw4.WriteLine(adatok7[0] + ": " + adatok7[1]);
	}
}
sw4.Close();

//7 - Állítsa növekvő sorrendbe a posztok szerint a játékosok ösz magasságát
Dictionary<string, double> positions = new Dictionary<string, double>();
foreach (var line8 in lines)
{
	string[] data8 = line8.Split('\t');
	if (positions.ContainsKey(data8[2]))
	{
		positions[data8[2]] += Convert.ToDouble(data8[1]);
	}
	else
	{
		positions.Add(data8[2], Convert.ToDouble(data8[1]));
	}
}
StreamWriter sw5 = new StreamWriter(path + "posztok.txt");
foreach (var position in positions.OrderBy(x => x.Key))
{
	sw5.WriteLine(position.Key + ": " + position.Value);
}
sw5.Close();

//8 - Egy szöveges állományba, „alacsonyak.txt” keresse ki a játékosok átlagmagasságától alacsonyabb játékosokat. Az állomány tartalmazza a játékosok nevét, magasságát és hogy mennyivel alacsonyabbak az átlagnál, 2 tizedes pontossággal.
StreamWriter sw6 = new StreamWriter(path + "alacsonyak.txt");
foreach (var line9 in lines)
{
	string[] data10 = line9.Split('\t');
	if (Convert.ToDouble(data10[1]) < averageHeight)
	{
		sw6.WriteLine(data10[0] + ": " + data10[1] + " " + Math.Round(averageHeight - Convert.ToDouble(data10[1]), 2));
	}
}
sw6.Close();
//9 - Határozza meg, hogy melyik országban hány játékos szerepel és mentsük el az adatokat az orszagok.txt állományba.
Dictionary<string, int> countries = new Dictionary<string, int>();
foreach (var line10 in lines)
{
	string[] data11 = line10.Split('\t');
	if (countries.ContainsKey(data11[5]))
	{
		countries[data11[5]]++;
	}
	else
	{
		countries.Add(data11[5], 1);
	}
}
StreamWriter sw7 = new StreamWriter(path + "orszagok.txt");
foreach (var country in countries)
{
	sw7.WriteLine(country.Key + ": " + country.Value);
}
sw7.Close();
//10 - Határozza meg, hogy melyik országban hány játékos szerepel és mentsük el az adatokat az orszagok.txt állományba.
Dictionary<string, int> teams = new Dictionary<string, int>();
foreach (var line11 in lines)
{
	string[] data12 = line11.Split('\t');
	if (teams.ContainsKey(data12[4]))
	{
		teams[data12[4]]++;
	}
	else
	{
		teams.Add(data12[4], 1);
	}
}
StreamWriter sw8 = new StreamWriter(path + "csapatok.txt");
foreach (var team2 in teams)
{
	sw8.WriteLine(team2.Key + ": " + team2.Value);
}
sw8.Close();

//11 - Kérje be a felhasználótól egy játékos nevét, majd írja ki a képernyőre a játékos adatait. Ha a játékos nem szerepel az adatok között, akkor írja ki a „Nincs ilyen játékos az adatbázisban” szöveget.
Console.WriteLine("Add meg a játékos nevét:");
string playerName = Console.ReadLine();
bool found = false;
foreach (var line12 in lines)
{
	string[] data13 = line12.Split('\t');
	if (data13[0] == playerName)
	{
		Console.WriteLine(line12);
		found = true;
	}
}
if (!found)
{
	Console.WriteLine("Nincs ilyen játékos az adatbázisban");
}
//12 - Kérje be a felhasználótól egy ország nevét, majd írja ki a képernyőre az adott országban szereplő játékosok adatait. Ha az országban nem szerepel játékos, akkor írja ki a „Nincs ilyen országban játékos” szöveget.
Console.WriteLine("Add meg az ország nevét:");
string countryName = Console.ReadLine();
bool found2 = false;
foreach (var line13 in lines)
{
	string[] data14 = line13.Split('\t');
	if (data14[5] == countryName)
	{
		Console.WriteLine(line13);
		found2 = true;
	}
}
if (!found2)
{
	Console.WriteLine("Nincs ilyen országban játékos");
}
//13 - Kérje be a felhasználótól egy csapat nevét, majd írja ki a képernyőre az adott csapatban szereplő játékosok adatait. Ha a csapatban nem szerepel játékos, akkor írja ki a „Nincs ilyen csapatban játékos” szöveget.
Console.WriteLine("Add meg a csapat nevét:");
string teamName = Console.ReadLine();
bool found3 = false;
foreach (var line14 in lines)
{
	string[] data15 = line14.Split('\t');
	if (data15[4] == teamName)
	{
		Console.WriteLine(line14);
		found3 = true;
	}
}
if (!found3)
{
	Console.WriteLine("Nincs ilyen csapatban játékos");
}
//14 - Kérje be a felhasználótól egy poszt nevét, majd írja ki a képernyőre az adott posztban szereplő játékosok adatait. Ha a posztban nem szerepel játékos, akkor írja ki a „Nincs ilyen posztban játékos” szöveget.
Console.WriteLine("Add meg a poszt nevét:");
string positionName = Console.ReadLine();
bool found4 = false;
foreach (var line15 in lines)
{
	string[] data16 = line15.Split('\t');
	if (data16[2] == positionName)
	{
		Console.WriteLine(line15);
		found4 = true;
	}
}
if (!found4)
{
	Console.WriteLine("Nincs ilyen posztban játékos");
}
