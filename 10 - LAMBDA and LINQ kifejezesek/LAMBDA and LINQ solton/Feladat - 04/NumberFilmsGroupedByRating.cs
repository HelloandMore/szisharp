public class NumberFilmsGroupedByRating
{
	public string RatingName { get; set; }

	public int NumberOfFilms { get; set; }

	public NumberFilmsGroupedByRating() { }

	public NumberFilmsGroupedByRating(string ratingName, int numberOfFilms)
	{
		RatingName = ratingName;
		NumberOfFilms = numberOfFilms;
	}
}
