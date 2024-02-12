using System;
using System.Collections.Generic;

public class ActionMovies
{
	public string Director { get; set; }

	public List<DateTime> ReleaseYears { get; set; }

	public ActionMovies() { }

	public ActionMovies(string director, List<DateTime> releaseYear)
	{
		Director = director;
		ReleaseYears = releaseYear;
	}
}