using IOLibrary;

const int NUMBER_OF_SONGS = 3;

//Milyen hosszú a lemez percekben feltüntetve?
Song[] songs = GetSongs();
Console.WriteLine("Zenék összesítve: \n");
ExtendedConsole.WriteArrayToConsole(songs);

int totalLength = songs.Sum(song => song.Length);
Console.WriteLine($"\nA lemez percekben feltüntetve {totalLength / 60} perc");

double averageLength = songs.Average(song => song.Length);
Console.WriteLine($"\nAz átlag hossz az albumon belül {ExtendedConsole.FormatTime(averageLength)}");

int shortestSongValue = songs.Min(song => song.Length);
Song shortestSong = songs.First(song => song.Length == shortestSongValue);
Console.WriteLine($"\nA legrövidebb zene: {shortestSong}");

bool longerThan4Mins = songs.Any(song => song.Length > 240);
Console.WriteLine($"\n{(longerThan4Mins ? "Volt" : "Nem volt")} az albumon belül 4 percnél hosszabb szám");

int longestLength = songs.Max(song => song.Length);
Song longestSong = songs.First(song => song.Length == longestLength);
Console.WriteLine($"\nLeghosszabb zene az albumon belül a(z) {longestSong.Placement}. helyen van");

Song[] sameLengthSongs = SameLengthSongNames(songs);
Console.WriteLine($"\n{((sameLengthSongs.Length == 0) ? "Nincs" : "Van")} egyforma hosszúságú zene");
ExtendedConsole.WriteArrayToConsole(sameLengthSongs);

Song[] SameLengthSongNames(Song[] songs)
{
	Song[] sameLength = new Song[NUMBER_OF_SONGS * 2];
	int index = -1;

	for (int i = 0; i < NUMBER_OF_SONGS - 1; i++)
	{
		for (int j = i + 1; j < NUMBER_OF_SONGS; j++)
		{
			if (songs[i].Length == songs[j].Length)
			{
				sameLength[++index] = songs[i];
				sameLength[++index] = songs[j];
			}
		}
	}
	return sameLength;
}

Song[] GetSongs()
{
	Song[] songs = new Song[NUMBER_OF_SONGS];
	Random rand = new Random();
	for (int i = 0; i < NUMBER_OF_SONGS; i++)
	{
		string name = ExtendedConsole.ReadString($"Add meg a(z) {i + 1}. zene nevét > ");
		int length = rand.Next(20, 500);
		songs[i] = new Song(name, length, i + 1);
	}
	return songs;
}