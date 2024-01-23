using IOLibrary;

class Song
{
	public string Title { get; }
	public int Duration { get; }

	public Song(string title, int duration)
	{
		Title = title;
		Duration = duration;
	}

	public override string ToString()
	{
		int minutes = Duration / 60;
		int seconds = Duration % 60;
		return $"{Title} ({minutes}:{seconds:D2})";
	}
}

class Album
{
	private List<Song> songs = new List<Song>();

	public void AddSong(string title)
	{
		Random random = new Random();
		int duration = random.Next(20, 501);
		Song song = new Song(title, duration);
		songs.Add(song);
	}

	public (int, int) CalculateTotalDuration()
	{
		int totalDuration = songs.Sum(song => song.Duration);
		return (totalDuration / 60, totalDuration % 60);
	}

	public double CalculateAverageDuration()
	{
		double totalDuration = songs.Sum(song => song.Duration);
		return totalDuration / songs.Count;
	}

	public Song FindShortestSong()
	{
		return songs.OrderBy(song => song.Duration).First();
	}

	public bool HasLongerThan4Minutes()
	{
		return songs.Any(song => song.Duration > 240);
	}

	public int FindLongestSongIndex()
	{
		int longestSongIndex = songs.IndexOf(songs.OrderByDescending(song => song.Duration).First());
		return longestSongIndex + 1;
	}

	public void ListSongs()
	{
		for (int i = 0; i < songs.Count; i++)
		{
			Console.WriteLine($"{i + 1} - {songs[i]}");
		}
	}

	public bool HasDuplicateDurations(out List<Song> duplicateSongs)
	{
		var duplicateGroups = songs.GroupBy(song => song.Duration).Where(group => group.Count() > 1);
		duplicateSongs = duplicateGroups.SelectMany(group => group).ToList();
		return duplicateGroups.Any();
	}

	public override string ToString()
	{
		(int minutes, int seconds) = CalculateTotalDuration();
		return $"{minutes} perc {seconds} másodperc";
	}
}

class Program
{
	static void Main()
	{
		Album album = new Album();

		for (int i = 0; i < 3; i++)
		{
			string songName = ExtendedConsole.ReadString($"Add meg a(z) {i + 1}. zene címét > ");
			album.AddSong(songName);
			// album.AddSong($"Song {i+1}");
		}

		album.ListSongs();

		Console.WriteLine("\na) Album hossza: " + album);
		Console.WriteLine("b) Átlagos zeneszámhossz: " + album.CalculateAverageDuration());
		Console.WriteLine("c) Legrövidebb zeneszám: " + album.FindShortestSong());
		Console.WriteLine("d) Van-e 4 percnél hosszabb zeneszám: " + album.HasLongerThan4Minutes());
		Console.WriteLine("e) A leghosszabb zeneszám sorszáma: " + album.FindLongestSongIndex());

		List<Song> duplicateSongs;
		if (album.HasDuplicateDurations(out duplicateSongs))
		{
			Console.WriteLine("f) Van-e két egyforma hosszúságú zeneszám:");
			foreach (var song in duplicateSongs)
			{
				Console.WriteLine($"   - {song}");
			}
		}
		else
		{
			Console.WriteLine("f) Nincs két egyforma hosszúságú zeneszám.");
		}
	}
}
