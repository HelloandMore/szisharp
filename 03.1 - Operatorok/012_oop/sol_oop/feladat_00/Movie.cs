public class Movie
{
	public int ReleaseDate { get; set; }
	
	public string MovieTitle { get; set; }

	public string MovieDirector { get; set; }

	public int MovieLength { get; set; }

	public string MovieGenre { get; set; }

	public override string ToString()
	{
		return $"{this.MovieTitle} released in {this.ReleaseDate}, directed by {this.MovieDirector}\nGenre: {this.MovieGenre}\nLenght: {this.MovieLength} minutes";
	}
}
