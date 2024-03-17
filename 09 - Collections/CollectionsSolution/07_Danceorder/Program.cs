// 1.
using Custom.Library.SystemExtensions;
using IOLibrary;
using System.Net.Http.Headers;

List<DanceTypeAndCoupleNames> danceTypeAndCoupleNames = await FileService.GetDanceTypeAndCoupleNames("tancrend.txt");
List<string> dancesList = danceTypeAndCoupleNames.Select(x => x.DanceName.ToLower()).Distinct().ToList();

// 2.
string firstDance = danceTypeAndCoupleNames[0].DanceName.ToLower();
string lastDance = danceTypeAndCoupleNames[danceTypeAndCoupleNames.Count - 1].DanceName.ToLower();

Console.WriteLine($"Elsőként bemutatott tánc neve: {firstDance}");
Console.WriteLine($"Utolsóként bemutatott tánc neve: {lastDance}");

// 3.
int amountOfSamba = danceTypeAndCoupleNames.Where(x => x.DanceName.ToLower() == "samba").Count();
Console.WriteLine($"\nEnnyi pár mutatta be a sambát: {amountOfSamba}");

// 4.
List<DanceTypeAndCoupleNames> VilmaInDances = danceTypeAndCoupleNames.Where(x => x.GirlName.ToLower() == "Vilma").ToList();
Console.WriteLine("\nVilma ezekben a táncokban szerepelt:");
foreach (var item in VilmaInDances)
{
	Console.WriteLine(item.DanceName);
}

// 5.
Console.WriteLine("\nElérhető táncok:");
foreach (var item in danceTypeAndCoupleNames.DistinctBy(x => x.DanceName.ToLower()))
{
	Console.WriteLine(item.DanceName);
}
string inputDanceName = ExtendedConsole.ReadString("\nVálassz az elérhető táncok közül > ");

while (!dancesList.Contains(inputDanceName))
{
	Console.WriteLine("\nNincs ilyen tánc az adatbázisban");
    Console.WriteLine("Elérhető táncok:");
	foreach (var item in danceTypeAndCoupleNames.DistinctBy(x => x.DanceName.ToLower()))
	{
        Console.WriteLine(item.DanceName);
    }
    inputDanceName = ExtendedConsole.ReadString("\nVálassz az elérhető táncok közül > ");
}

DanceTypeAndCoupleNames VilmainChosenDance = danceTypeAndCoupleNames.Where(x => x.DanceName.ToLower() == inputDanceName.ToLower() && x.GirlName.ToLower() == "vilma").FirstOrDefault();
if (VilmainChosenDance != null)
{
	Console.WriteLine($"\nA(z) {inputDanceName} bemutatóján Vilma párja {VilmainChosenDance.BoyName} volt.");
}
else
{
	Console.WriteLine($"Vilma nem táncolt {inputDanceName}-t.");
}

// 6.
await FileService.WriteListToFileAsync(danceTypeAndCoupleNames.Select(x => x.GirlName).ToList(), danceTypeAndCoupleNames.Select(x => x.BoyName).ToList(), "szereplok");

// 7. Írja ki a képernyőre, hogy melyik fiú szerepelt a legtöbbször a fiúk közül, és melyik lány a lányok közül! Ha több fiú, vagy több lány is megfelel a feltételeknek, akkor valamennyi fiú, illetve valamennyi lány nevét írja ki! 
Dictionary<string, int> boys = danceTypeAndCoupleNames.Select(x => x.BoyName).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
Dictionary<string, int> girls = danceTypeAndCoupleNames.Select(x => x.GirlName).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

int mostBoyAppearance = boys.Max(x => x.Value);
int mostGirlsAppearance = girls.Max(x => x.Value);

List<string> boyNameWithMostAppearance = boys.Where(x => x.Value == mostBoyAppearance).Select(x => x.Key).ToList();
List<string> girlNameWithMostAppearance = girls.Where(x => x.Value == mostGirlsAppearance).Select(x => x.Key).ToList();

Console.WriteLine($"\nA legtöbbször szereplő fiú(k):");
boyNameWithMostAppearance.WriteCollectionToConsole();

Console.WriteLine($"\nA legtöbbször szereplő lány(ok):");
girlNameWithMostAppearance.WriteCollectionToConsole();