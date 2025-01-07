/* Írj egy Hazmester nevű osztályt. Az osztály rendelkezzen egy Karbantart statikus függvénnyel, ami egy fájl elérési útját várja paraméterül, visszatérési értéke pedig void. A metódus példányosítson egy Tarsashaz-at. A metódus feladata ezután, hogy a fájlból beolvasott sorokat (ingatlanokat) feldolgozza, és létrehozzon belőlük Alberlet, CsaladiApartman és Garazs objektumokat. Ezeket az obejtumokat a megfelelő függvény használatával adja is hozzá a létrehozott társasházhoz. Miután végzett a fájl feldolgozásával, írja ki konzolra, hogy mennyi a társasház összes értéke. Minden esetleges kivételt (főleg FileNotFoundException és IOException) kezelj le kivételspeciﬁkációval, vagy try blokkba. Egy minta fájl felépítése az alábbi:
Alberlet 50.2 5 13000
CsaladiApartman 62.8 2 40000
Garazs 10.3 5000 futott
*/

using System.Runtime.CompilerServices;

public class Hazmester
{
	public static void Karbantart(string fajl)
	{
		Tarsashaz haz = new Tarsashaz();
		try
		{
			using (StreamReader sr = new StreamReader(fajl))
			{
				string sor;
				while ((sor = sr.ReadLine()) != null)
				{
					string[] adatok = sor.Split(' ');
					switch (adatok[0])
					{
						case "Alberlet":
							haz.UjAlberlet(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]), int.Parse(adatok[4]));
							break;
						case "CsaladiApartman":
							haz.UjCsaladiApartman(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
							break;
						case "Garazs":
							haz.UjGarazs(int.Parse(adatok[1]), int.Parse(adatok[2]), adatok[3] == "futott");
							break;
					}
				}
			}
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine("A fajl nem talalhato.");
		}
		catch (IOException)
		{
			Console.WriteLine("Hiba a fajl olvasasakor.");
		}
		Console.WriteLine($"A tarsashaz osszes erteke: {haz.OsszesErtek()}");
	}
}