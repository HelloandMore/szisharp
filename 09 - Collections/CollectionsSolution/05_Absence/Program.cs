//Ebben a feladatban egy általános iskola 2017 szeptemberi hiányzásai tartalmazó
//szövegfájlt kell feldolgoznia. Az adatok a szeptember.csv állomány tartalmazza. Az
//állomány egy sorában egy tanuló hiányzása szerepel. Minden hiányzás esetében ismert a
//tanuló neve és osztálya, a hiányzás első és utolsó napja, valamint a mulasztott órák
//száma.

//A fájlban az adatok ;-vel vannak elválasztva. Ezek a következők: "Név;Osztály;Első nap;Utolsó nap;Mulasztott órák"

//A megoldás során vegye figyelembe a következőket:
//- Az ékezetmentes kiírás is elfogadott!
//- A felhasználótól kapott adatokat nem kell ellenőriznie.
//- A feladat jobb megértése érdekében tanulmányozza a mintákat is!

//Készítsen konzolos programot, amely az alábbi feladatokat oldja meg!
//A feladatok elkészítéséhez .net 8.0-as szerkezetet használjon!
//A feladatok elkészítéséhez linq használata kötelező!

//1.Tárolja el a fájlok tartalmát olyan adatszerkezetben, amivel a további feladatok megoldhatók!
using IOLibrary;

List<Absence> absences = await FileService.ReadFromFileAsyncV2("szeptember.csv");

//2. Határozza meg, és írja ki a képernyőre, hogy a diákok összesen hány órát mulasztottak ebben a hónapban.
Console.WriteLine($"A diákok összesen {absences.Sum(x => x.Hours)} órát mulasztottak.");

//3. Kérjen be a felhasználótól
//- egy napot 1 és 30 között.
int day = ExtendedConsole.ReadInteger("Kérem adja meg a napot > ", 30, 1);

//- egy tanuló nevét.
string name = ExtendedConsole.ReadString("Kérem adja meg a tanuló nevét > ");

//4. Írja ki a képernyőre, hogy az előző feladatban beért tanulónak volt-e hiányzása! A „A tanuló hiányzott szeptemberben” vagy „A tanuló nem hiányzott szeptemberben” szöveget jelenítse meg.
bool absence = absences.Any(x => x.Name.ToLower() == name.ToLower() && x.FirstDay <= day && x.LastDay >= day);
Console.WriteLine(absence ? "A tanuló hiányzott szeptemberben" : "A tanuló nem hiányzott szeptemberben");

//5. Írja ki a képernyőre azon tanulók nevét és osztályát a minta szerint, akik a 3. feladatban bekért napon hiányoztak! (Ha a 3. feladatot nem tudta megoldani, akkor a 19-ei nappal dolgozzon!) Ha nem volt hiányzó, akkor a „Nem volt hiányzó” szöveget jelenítse meg!
Console.WriteLine($"Hiányzók 2017.09.{day}.-án/én:");
var result = absences.Where(x => x.FirstDay <= day && x.LastDay >= day).ToList();
if (result.Count == 0)
{
    Console.WriteLine("Nem volt hiányzó");
}
else
{
    foreach (var item in result)
    {
        Console.WriteLine($"{item.Name}, {item.Class}");
    }
}

//6. Készítsen összesítést, amely osztályonként fájlba írja a mulasztott órák számát! Az osszesites.csv nevű fájl tartalmazza az osztályt és a mulasztott órák számának összegét!
List<Absence> absences1 = absences.GroupBy(x => x.Class).Select(x => new Absence
{
	Class = x.Key,
	Hours = x.Sum(x => x.Hours)
}).ToList();
FileService.WriteCollectionToFile("osszesites", absences1);