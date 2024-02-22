//1. Írjuk ki a képernyőre az össz adatot
using Custom.Library.SystemExtensions;

List<Books> books = await FileService.ReadFromFileAsync("adatok.txt");
books.WriteCollectionToConsole();


//2. Keressük ki az informatika témajú könyveket és mentsük el őket az informatika.txt állömányba
List<Books> itBooks = books.Where(x => x.Topic == "informatika").ToList();


//3. Az 1900.txt állományba mentsük el azokat a könyveket amelyek az 1900-as években íródtak
List<Books> books1900 = books.Where(x => x.PublishYear >= 1900 && x.PublishYear < 2000).ToList();
FileService.WriteCollectionToFile("1900", books1900);


//4. Rendezzük az adatokat a könyvek oldalainak száma szerint csökkenő sorrendbe és a sorbarakott.txt állományba mentsük el.
List<Books> booksByPageCount = books.OrderByDescending(x => x.PageCount).ToList();
FileService.WriteCollectionToFile("sorbarakott", booksByPageCount);


//5. „kategoriak.txt” állományba mentse el a könyveket téma szerint. Például:
// Thriller:
//-könnyv1
//- könnyv2
// Krimi:
//-könnyv1
//- könnyv2

Dictionary<string, List<string>> booksByTopic = books.GroupBy(x => x.Topic).ToDictionary(x => x.Key, x => x.Select(x => x.Title).ToList());
FileService.WriteCollectionToFileString("kategoriak", booksByTopic);