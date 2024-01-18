using IOLibrary;
using System.Diagnostics.Metrics;

const int NUMBER_OF_SONGS = 3;

Song[] songs = GetSongs();
Console.WriteLine("Zenék összesítve: \n");
ExtendedConsole.WriteArrayToConsole(songs);

int totalLength = songs.Sum(song => song.Length);
Console.WriteLine($"\nA lemez percekben feltüntetve {totalLength/60} pörc");

double averageLength = songs.Average(song => song.Length);
Console.WriteLine($"\nAz átlag hossz az albumon belül {averageLength/60:F0}:{averageLength - ((int)(averageLength / 60)*60):F0} másodperc");

int shortestSongValue = songs.Min(song => song.Length);
Song shortestSong = songs.First(song => song.Length == shortestSongValue);
Console.WriteLine($"\nA legrövidebb zene: {shortestSong}");

bool longerThan4Mins = songs.Any(song => song.Length > 240);
Console.WriteLine($"\n{(longerThan4Mins?"Volt":"Nem volt")} az albumon belül 4 percnél hosszabb szám");

int longestLength = songs.Max(song => song.Length);
Song longestSong = songs.First(song => song.Length == longestLength);
Console.WriteLine($"\nLeghosszabb zene az albumon belül a(z) {longestSong.Placement}. helyen van");

Song[] checkSongs = songs;
int counter = 0;
for (int i = 0; i < NUMBER_OF_SONGS; i++)
{
	for(int j = 0; j < NUMBER_OF_SONGS; j++)
	{
		if ((songs[i].Length == songs[j].Length) && (i != j))
		{
			counter++;
			checkSongs[j].Length = 0;
		}
	}
	Console.WriteLine(songs[i].Length);
}

Console.WriteLine(counter);

Song[] GetSongs()
{
	Song[] songs = new Song[NUMBER_OF_SONGS];
	Random rand = new Random();
	for (int i = 0; i < NUMBER_OF_SONGS; i++)
	{
		string name = ExtendedConsole.ReadString($"Add meg a(z) {i+1}. zene nevét > ");
		int length = rand.Next(20, 500);
		songs[i] = new Song(name, length, i + 1);
	}
	return songs;
} 