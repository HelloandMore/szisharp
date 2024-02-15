using Custom.Library.SystemExtensions;

List<Student> students = await FileService.ReadFromFileAsyncV2("adatok.txt");

//Egy szöveges  állományban, adatok.txt, az érettségizők pontjai vannak elmentve a következő módón,
//soronként és a sorokban tabulátorral elválasztva:

//Virág   9,28
//Jázmin	6,26

//Feladatunk, hogy
//1 - Írjuk ki minden diák adatát a képernyőre!

//ExtendedSystem.WriteCollectionToConsole fasze nem létezik anyad

//2 - Hány diák jár az osztályba?
int classSize = students.Count;
Console.WriteLine($"\nÖsszesen {classSize} diák jár az osztályba");

//3 - Mennyi az osztály átlaga?
double classAverage = students.Average(x => x.Average);
Console.WriteLine($"\nAz osztály átlaga: {classAverage}");

//4 - Keressük a legtöbb pontot elért érettségizőt és írjuk ki az adatait a képernyőre.
Student bestStudent = students.MaxBy(x => x.Average);
Console.WriteLine($"\nA osztály legjobb tanulója: {bestStudent}");
Console.WriteLine();

//5 - atlagfelett.txt allományba keressük ki azon tanulókat kiknek pontjai meghaladják az átlagot!
List<Student> studentsAboveAverage = students.Where(x => x.Average > classAverage).ToList();

//6 - Van e kitünő tanulónk?
//7 - Hány elégtelen, elégséges, jó, jeles és kitünő tanuló van az osztályban?
//    Értékhatárok:
//	-elégtelen, ha: 0.00 - 1.99
//	- elégséges, ha: 2.00 - 2.99
//	- jó, ha: 3.00 - 3.99
//	- jeles, ha: 4.00 - 4.99
//	- kitünő, ha: 5.00