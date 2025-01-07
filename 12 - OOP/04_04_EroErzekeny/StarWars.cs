/* • Írj egy StarWars nevű osztályt. Az osztály rendelkezzen egy Szereplok statikus függvénnyel, ami egy fájl elérési útját várja paraméterül, visszatérése pedig void. A metódus feladata, hogy a fájlból beolvasott sorokat feldolgozza, és létrehozzon belőlük AnakinSkywalker, vagy Uralkodo objektumpéldányokat, majd ezekre meghívja az EngeddElAHaragod metódust annyiszor, ahányszor az aktuális sor írja. Ezeket egy közös gyüjteményeban tárold le. Készíts továbbá egy Sithek statikus metódust, ami végigmegy a tárolóban tárolt objektumokon, és kiírja őket. Hívd meg a main függvényben sorban a fenti két metódust. Minden esetleges kivételt (főleg: IOException) kezelj le vagy kivétel speciﬁkációval, vagy try blokkban!
Egy minta fájl felépítése az alábbi:
Anakin 5
Uralkodo 8
*/

public class StarWars
{
	private static List<IEroErzekeny> erok = new List<IEroErzekeny>();
	public static void Szereplok(string fajl)
	{
		try
		{
			StreamReader sr = new StreamReader("../../../source/" + fajl);
			string sor;
			while ((sor = sr.ReadLine()) != null)
			{
				string[] adatok = sor.Split(' ');
				if (adatok[0] == "Anakin")
				{
					AnakinSkywalker anakin = new AnakinSkywalker();
					for (int i = 0; i < int.Parse(adatok[1]); i++)
					{
						anakin.EngeddElAHaragod();
					}
					erok.Add(anakin);
				}
				else if (adatok[0] == "Uralkodo")
				{
					Uralkodo uralkodo = new Uralkodo();
					for (int i = 0; i < int.Parse(adatok[1]); i++)
					{
						uralkodo.EngeddElAHaragod();
					}
					erok.Add(uralkodo);
				}
			}
			sr.Close();
		}
		catch (IOException e)
		{
			Console.WriteLine(e.Message);
		}
	}

	public static void Sithek()
	{
		
		foreach (IEroErzekeny ero in erok)
		{
			if (ero is Sith)
			{
				Sith sith = (Sith)ero;
				sith.EngeddElAHaragod();
				Console.WriteLine(sith);
			}
		}
	}

	public static void Main()
	{
		Szereplok("StarWars.txt");
		Sithek();
	}
}