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

void WriteOrderedToConsole(string text, ICollection<MotorOrdered> motorcycless)
{
	Console.WriteLine(text);
	Console.WriteLine(string.Join('\n', motorcycless));
}

void WriteStringtoConsole(string text, ICollection<string> motorcycless)
{
	Console.WriteLine(text);
	Console.WriteLine(motorcycless);
}

void WriteInttoConsole(string texet, ICollection<int> motorcyclesss)
{
	Console.WriteLine(texet);
	Console.WriteLine(motorcyclesss);
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
WriteToConsole(isThereAnyBmwBf2010MinCB1000 ? "\nBMW-k, melyek 2010 előtt gyártottak, és legalább 1000 köbcentijű a motorja: " : "\nNincs olyan BMW, melyet 2010 előtt gyártottak, és legalább 1000 köbcentijű a motorja", BmwBf2010MinCB1000);

// 12 - Keressük a motorkerékpárok beceneveit (nickname)!
List<string> NicknamesForCycles = motorcycles.Select(x => x.Nickname).ToList();
WriteStringtoConsole("\nMotorok beceneve: ", NicknamesForCycles);


// 13 - Keressük azokat a motorkerékpárokat, melyek neveiben szerepel 'FZ' kifejezés!
List<Motorcycle> nicksContFZ = motorcycles.Where(x => x.Nickname.ToLower().Contains("fz")).ToList();
WriteToConsole("\nMotorok, melynek a nevében szerepel az 'FZ' kifejezés: ", nicksContFZ);


// 14 - Keressük azokat a motorkerékpárokat, melyek nevei 'C' betűvel kezdődnek!
List<Motorcycle> motorsWithStartingLetterC = motorcycles.Where(m => m.Nickname.ToLower().StartsWith("c")).ToList();
WriteToConsole("\nMotorok, melynek a nevei 'C' betűvel kezdődnek: ", motorsWithStartingLetterC);

// 15 - Keressük az első motorkerékpárt az 'adatbázisunkból'!
Motorcycle firstMotor = motorcycles.First();
WriteSingleToConsole("\nAz első motor az 'adatbázisban': ", firstMotor);

// 16 - Keressük az utolsó motorkerékpárt az 'adatbázisunkból'!
Motorcycle lastMotor = motorcycles.Last();
WriteSingleToConsole("\nAz utolsó motor az adatbázisban: ", lastMotor);

// 17 - Rendezzük növekvő sorrendbe gyártási év alapján az 'adatbázisban' szereplő motorkerékpárokat.
List<Motorcycle> orderdListByYear = motorcycles.OrderBy(m => m.ReleaseYear).ToList();
WriteToConsole("\nGyártási év alapján sorba rendezve az adatbázis elemei: ", orderdListByYear);

// 18 - Rendezzük csökkenő sorrendbe a 'Honda' által gyártott motorkerékpárokat, melyek teljesítménye legalább 25kW és 2005 után gyártották őket.
List<Motorcycle> orderedListOfHondas = motorcycles.Where(m => m.Brand == "Honda" && m.KW >= 25 && m.ReleaseYear > 2005)
												   .OrderByDescending(m => m.KW).ToList();
WriteToConsole("\n'Honda' által gyártott motorkerékpárok, melyek teljesítménye legalább 25kW és 2005 után gyártották őket: ", orderedListOfHondas);

// 19 - Melyek azok a  motorkerékpárok, melyek nem rendelkeznek becenévvel?
List<Motorcycle> motorsWithNicknames = motorcycles.Where(m => m.Nickname is null).ToList();
WriteToConsole("\nMotorok, melyeknek nincs beceneve: ", motorsWithNicknames);

// 20 - Mekkora az 'adatbázisban' szereplő motorkerékpárok sebességének az átlaga?
double averageSpeed = motorcycles.Average(m => m.TopSpeed);
Console.WriteLine($"\nMotorok átlagsebessége: {averageSpeed}");

// 21 - Melyik a legyorsabb motorkerékpár? Feltételezzük, hogy csak egy ilyen van!
Motorcycle fastestMotor = motorcycles.MaxBy(m => m.TopSpeed);
WriteSingleToConsole("\nLeggyorsabb motor az adatbázisban: ", fastestMotor);

// 22 - Hány kategória található meg az 'adatbázisban'?
int numberOfCategories = motorcycles.Select(m => m.Category).Distinct().Count();
Console.WriteLine($"\nAz adatbázisban {numberOfCategories} kategória van");

// 23 - Határozza meg az 'adatbázisban' talalható motorkerékpárok átlag életkorát!
double averageAgeOfMotors = motorcycles.Average(m => DateTime.Now.Year - m.ReleaseYear);
Console.WriteLine($"\nÁtlag kora a motoroknak: {averageAgeOfMotors}");

// 24 - Van-e 'Java' gyártmányú motorkerékpár az 'adatbázisban'?
bool isThereMotorMadeByJava = motorcycles.Any(m => m.Brand.ToLower() == "java");
Console.WriteLine($"\n{(isThereMotorMadeByJava ? "Van" : "Nincs")} olyan motor az adatbázisban, mely 'Java' gyártmányú");

// 25 - Rendezzül növekvő sorrende az 5 betűvel rendelkező gyártók motorkerékpárjait,
//         majd csökkenő sorrendbe gyártási év alapján és az eredményben csak a nevet és
//         a gyártási évet jelenítse meg!

List<MotorOrdered> motorOrdereds = motorcycles.Where(m => m.Brand.Length == 5)
											   .OrderBy(m => m.Brand)
											   .ThenByDescending(m => m.ReleaseYear)
											   .Select(m => new MotorOrdered
											   {
												   MotorName = m.Nickname,
												   ReleasYear = m.ReleaseYear,
											   })
											   .ToList();
WriteOrderedToConsole("\nMotorok növekvő sorrende az 5 betűvel rendelkező gyártók szerint, majd csökkenő sorrendbe gyártási év alapján és az eredményben csak a név és a gyártási év jelenjen meg: ", motorOrdereds);
Console.ReadLine();
