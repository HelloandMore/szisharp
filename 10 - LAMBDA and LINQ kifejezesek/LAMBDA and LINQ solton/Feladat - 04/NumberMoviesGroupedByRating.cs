public class NumberMoviesGroupedByRating
{
	public string RatingName { get; set; }

	public int NumberOfMovies { get; set; }

	public NumberMoviesGroupedByRating() { }

	public NumberMoviesGroupedByRating(string ratingName, int numberOfMovies)
	{
		RatingName = ratingName;
		NumberOfMovies = numberOfMovies;
	}
}
