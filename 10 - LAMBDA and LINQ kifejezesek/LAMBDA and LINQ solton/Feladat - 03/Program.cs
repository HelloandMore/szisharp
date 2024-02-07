using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

List<Motorcycle> LoadData()
{
	FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None);
	StreamReader sr = new StreamReader(fs, Encoding.UTF8);

	string jsonData = sr.ReadToEnd();
	return JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);

}

void WriteToConsole(string text, ICollection<Motorcycle> motorcycles)
{
	Console.WriteLine(text);
	Console.WriteLine(string.Join('\n', motorcycles));
}

void WriteNickToConsole(string text, ICollection<Nicknames> nicknames)
{
	Console.WriteLine(text);
	Console.WriteLine(string.Join('\n', nicknames));
}

void WriteSingleToConsole(string text, Motorcycle motorcycle)
{
	Console.WriteLine(text);
	Console.WriteLine(motorcycle);
}


List<Motorcycle> motorcycles = LoadData();
WriteToConsole("Data", motorcycles);

// 1 - Hány motorkerékpár van az 'adatbázisban' ?
int numOfBikes = motorcycles.Count;
Console.WriteLine($"Az adatbázisban ennyi motorkerékbár szerepel: {numOfBikes}\n");


// 2 - Hány 'Honda' gyártmányú motorkerékpár van az 'adatbázisban' ?

int brandHonda = motorcycles.Count(x => x.Brand == "Honda");
Console.WriteLine($"Honda gyártású motorból ennyi van: {brandHonda}\n");


// 3 - Mekkora a legnyaobb köbcenti az 'adatbázisban' ?
int mostCubicMetres = motorcycles.Max(x => x.Cubic);
Console.WriteLine($"A legnyaobb köbcenti az 'adatbázisban': {mostCubicMetres}\n");

// 4 - Melyik a legkisebb végsebesség az 'adatbázisban' ?
int slowestMaxspeed = motorcycles.Min(x => x.TopSpeed);
Console.WriteLine($"A legalacsonyabb végsebességű motor az 'adatbázisban': {slowestMaxspeed}\n");


// 5 - Van e olyan motorkerékpár az 'adatbázisban' amelyet 1960 előtt gyártottak?

bool isThereAnyBefore1960 = motorcycles.Any(x => x.ReleaseYear < 1960);
Console.Write(isThereAnyBefore1960 ? "Van " : "Nincs ");
Console.WriteLine("1960 előtt gyártott motorkerékpár az 'adatbázisban'\n");


// 6 - Van-e 'Honda' gyártmányú motorkerképár az 'adatbázisban' melynek beceneve 'Hornet' ?

bool isThereAnyHondaCalledHornet = motorcycles.Any(x => x.Brand == "Honda" && x.Nickname == "Hornet");
Console.Write(isThereAnyHondaCalledHornet ? "Van " : "Nincs ");
Console.WriteLine("olyan Honda motor az 'adatbázisban', melynek a beceneve 'Hornet'\n");


// 7 - Keressük ki a 'Yamaha' gyártmányú motorkerékpárokat!
bool isThereAnyYahamaCycles = motorcycles.Any(x => x.Brand == "Yamaha");
List<Motorcycle> YamahaCycles = motorcycles.Where(x => x.Brand == "Yamaha").ToList();
WriteToConsole(isThereAnyYahamaCycles ? "\nYamaha gyármátú motorok az 'adatbázisban': " : "Nincs Yamaha gyármányú motor az 'adatbázisban'", YamahaCycles);


// 8 - Keressük a 'Suzuki' gyártotmányú motorkerékpárokat melyek 600ccm felett vannak!
bool isThereAnySuzukisAbove660 = motorcycles.Any(x => x.Brand == "Suzuki" && x.Cubic > 600);
List<Motorcycle> SuzukisAbove660 = motorcycles.Where(x => x.Brand == "Suzuki" && x.Cubic > 600).ToList();
WriteToConsole(isThereAnySuzukisAbove660 ? "\n'Suzuki' gyártotmányú motorkerékpárok, amelyeket 600 kcm felett vannak: " : "\nNincsenek 'Suzuki' gyártotmányú motorkerékpárok 600 kcm felett", SuzukisAbove660);


// 9 - Keressük ki a 'Kawasaki' gyártotmányú motorkerékpárokat, melyek sebesságe nagyobb min 150km/h!
bool isThereAnyKawasakiAbove150Max = motorcycles.Any(x => x.Brand == "Kawasaki" && x.TopSpeed > 150);
List<Motorcycle> KawasakiAbove150Max = motorcycles.Where(x => x.Brand == "Kawasaki" && x.TopSpeed > 150).ToList();
WriteToConsole(isThereAnyKawasakiAbove150Max ? "\nKawasaki 'gyártotmányú' motorkerékpárok, melyek 'végsebesságe' meghaladja a 150 km/h-t: " : "\n Nincsen Kawasaki 'gyártotmányú' motor, mely meghaladja a 150 km/h végsebességet", KawasakiAbove150Max);


// 10 - Keressük ki a 'BMW' gyártotmányú motorkerékpárokat, melyeket 2010 előtt gyárottak és a motor köbcentije minimum 1000!
bool isThereAnyBmwBf2010MinCB1000 = motorcycles.Any(x => x.Brand == "BMW" && x.ReleaseYear < 2010 && x.Cubic >= 1000);
List<Motorcycle> BmwBf2010MinCB1000 = motorcycles.Where(x => x.Brand == "BMW" && x.ReleaseYear < 2010 && x.Cubic >= 1000).ToList();
WriteToConsole(isThereAnyBefore1960 ? "\nBMW-k, melyek 2010 előtt gyártottak, és legalább 1000 köbcentijű a motorja: " : "\nNincs olyan BMW, melyet 2010 előtt gyártottak, és legalább 1000 köbcentijű a motorja", BmwBf2010MinCB1000);


// 12 - Keressük a motorkerékpárok beceneveit (nickname)!
List<Nicknames> NicknamesForCycles = motorcycles.GroupBy(g => g.Nickname)
									 .Select(n => new Nicknames
									 {
										 Nickname = n.Key,
										 Brand = motorcycles.Select(g => g.Nickname).ToString()
									 }).ToString();


// 13 - Keressük azokat a motorkerékpárokat, melyek neveiben szerepel 'FZ' kifejezés!
List<string> nameContainsFZ = motorcycles.Contains(x => x.Nickname == "FZ");


// 14 - Keressük azokat a motorkerékpárokat, melyek nevei 'C' betűvel kezdődnek!


// 15 - Keressük az első motorkerékpárt az 'adatbázisunkból'!


// 16 - Keressük az utolsó motorkerékpárt az 'adatbázisunkból'!


// 17 - Rendezzük növekvő sorrendbe gyártási év alapján az 'adatbázisban' szereplő motorkerékpárokat.


// 18 - Rendezzük csökkenő sorrendbe a 'Honda' által gyártott motorkerékpárokat, melyek teljesítménye legalább 25kW és 2005 után gyártották őket.


// 19 - Melyek azok a  motorkerékpárok, melyek nem rendelkeznek becenévvel?


// 20 - Mekkora az 'adatbázisban' szereplő motorkerékpárok sebességének az átlaga?


// 21 - Melyik a legyorsabb motorkerékpár? Feltételezzük, hogy csak egy ilyen van!


// 22 - Hány kategória található meg az 'adatbázisban'?


// 23 - Határozza meg az 'adatbázisban' talalható motorkerékpárok átlag életkorát!


// 24 - Van-e 'Java' gyártmányú motorkerékpár az 'adatbázisban'?


// 25 - Rendezzül növekvő sorrende az 5 betűvel rendelkező gyártók motorkerékpárjait,
//         majd csökkenő sorrendbe gyártási év alapján és az eredményben csak a nevet és
//         a gyártási évet jelenítse meg!

Console.ReadLine();
