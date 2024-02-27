//A roplabda.txt állományban az adatok a következő módón vannak tárolva:
//Név,
//Magasság,
//Poszt,
//Nemzetiség,
//Csapat,
//Ország (ahol a csapat játszik)


//1 - Írjuk ki a képernyőre az összadatot.
using Custom.Library.SystemExtensions;

List<Player> players = FileService.ReadPlayersFromFile(".adatok.txt");
ExtendedSystem.WriteCollectionToConsole(players);

//2 - Keressük ki az ütő játékosokat, majd írjuk ki az utok.txt állományba.
List<Player> hitters = players.Where(x => x.Position == "ütő").ToList();
FileService.WriteCollectionToFile("utok", hitters);

//3 - A csapattagok.txt állományba mentsük a csapatokat és a hozzájuk tartozó játékosokat
//    a következő formában:
//  Telekom Baku: Yelizaveta Mammadova, Yekaterina Gamova,

Dictionary<string, List<string>> playersByTeam = players.GroupBy(x => x.Team, x => x.Name)
                                                        .ToDictionary(y => y.Key, y => y.ToList());

FileService.WriteCollectionToFileString("csapattagok", playersByTeam);

//4 - Rendezzük a játékosokat magasság szerint növekvő sorrendbe és a 
//    magaslatok.txt állományba mentsük el.

List<Player> orderedPlayers = players.OrderBy(player => player.Height).ToList();
FileService.WriteCollectionToFile("magaslatok", orderedPlayers);

//5 - Mutassuk be, hogy mely nemzetiségek képviseltetik
//    magukat a röplabdavilágban mint játékosok és milyen számban.
//    ezeket írjuk ki a nemzetisegek.txt állományba.

var playersByNationality = players.GroupBy(x => x.National, x => x.Name)
                                  .ToDictionary(y => y.Key, y => y.ToList());
FileService.WriteCollectionToFileString("nemzetisegek", playersByNationality);


//6 - atlagnalmagasabbak.txt állományba keressük azon játékosok nevét és magasságát
//    akik magasabbak mint az „adatbázisban” szereplő játékosok átlagos magasságánál.

double averageHeight = players.Average(x => x.Height);
List<Player> tallerThanAveragePlayers = players.Where(x => x.Height > averageHeight)
                                               .ToList();
FileService.WriteCollectionToFile("atlagnalmagasabbak", tallerThanAveragePlayers);

//7 - Állítsa növekvő sorrendbe a posztok szerint a játékosok összmagasságát.
//    A posztokat és az összmagasságokat írja a képernyőre.

var totalHeightByPosition = players.GroupBy(x => x.Position, x => x.Height)
                                   .ToDictionary(y => y.Key, y => y.Sum());
foreach (var item in totalHeightByPosition.OrderBy(item => item.Key))
{
    Console.WriteLine($"{item.Key}: {item.Value} cm");
}

//8 - Egy szöveges állományba, „alacsonyak.txt” keresse ki a játékosok átlagmagasságától
//    alacsonyabb játékosokat. Az állomány tartalmazza a játékosok nevét,
//	magasságát és hogy mennyivel alacsonyabbak az átlagnál, 2 tizedes pontossággal.


List<string> shorterThanAveragePlayers = players.Where(x => x.Height < averageHeight)
                                                .Select(x => $"{x.Name}, {x.Height}, {(averageHeight - x.Height):F2}")
                                                .ToList();
FileService.WriteCollectionToFileString("alacsonyak", new Dictionary<string, List<string>> { { "alacsonyak", shorterThanAveragePlayers } });