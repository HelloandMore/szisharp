using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

List<Movie> LoadData()
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };

    options.Converters.Add(new DateFormatConverter());

    FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None);
    StreamReader sr = new StreamReader(fs, Encoding.UTF8);
    
    string jsonData = sr.ReadToEnd();
    return JsonSerializer.Deserialize<List<Movie>>(jsonData, options);

}

 void WriteToConsole(string text, ICollection<Movie> movies)
{
    Console.WriteLine(text);
    Console.WriteLine(string.Join('\n', movies));
}

 void WriteSingleToConsole(string text, Movie movie)
{
    Console.WriteLine(text);
    Console.WriteLine(movie);
}

void WriteStringToConsole(string text, ICollection<string> movies)
{
    Console.WriteLine(text);
    Console.WriteLine(string.Join('\n', movies));
}

void WriteNumberFilmsGroupedByRatingToConsole(string text, ICollection<NumberFilmsGroupedByRating> movies)
{
	Console.WriteLine(text);
	Console.WriteLine(string.Join('\n', movies));
}

List<Movie> movies = LoadData();
WriteToConsole($"Data ({movies.Count})", movies);

// 1 - Hány film adatát dolgozzuk fel?
int numOfMovies = movies.Count;
Console.WriteLine($"\nEnnyi film adatát dolgozzuk fel: {numOfMovies}");

// 2 - Mekkora bevételt hoztak a filmek Amerikában?
long? sumOfRevUSA = movies.Sum(x => x.USGross);
Console.WriteLine($"\nA filmek összbevitele az USA-ban: {sumOfRevUSA}");

// 3 - Mekkora bevételt hoztak a filmek Világszerte?
long? sumOfRevWW = movies.Sum(x => x.WorldwideGross);
Console.WriteLine($"\nA filmek összbevitele világszerte: {sumOfRevWW}");

// 4 - Hány film jelent meg az 1990-es években?
int numOfMoviesFromtheNinties = movies.Where(x => x.ReleaseDate.Year >= 1990 && x.ReleaseDate.Year < 2000).Count();
Console.WriteLine($"\nA 90'-es években {numOfMoviesFromtheNinties} film jelent meg");

// 5 - Hányan szavaztak összessen az IMDB-n?
int? sumOfIMDBvotes = movies.Sum(x => x.IMDBVotes);
Console.WriteLine($"\nAz IMDB-n szavazók száma: {sumOfIMDBvotes}");

// 6 - Hányan szavaztak átlagossan az IMDB-n?
double? averageNumOfVotes = movies.Average(x => x.IMDBVotes);
Console.WriteLine($"\nÁtlagosan ennyien szavaztak az IMDB-n: {averageNumOfVotes}");

// 7 - A filmek világszerte átlagban mennyit hoztak a konyhára?
double? averageGrossWW = movies.Average(x => x.WorldwideGross);
Console.WriteLine($"\nÁtlagosan világszerte ennyi volt a filmet bevétele: {averageGrossWW}");

// 8 - Hány filmet rendezett 'Christopher Nolan' ?
int? amountOfMoviesByChris = movies.Where(x => x.Director?.ToLower() == "christopher nolan").Count();
Console.WriteLine($"\nEnnyi filmet rendezett Christopher Nolan: {amountOfMoviesByChris}");

// 9 - Melyik filmeket rendezte 'James Cameron'?
List<Movie> moviesDirectedByJames = movies.Where(x => x.Director?.ToLower() == "james cameron").ToList();
WriteToConsole("\nA következő filmeket James Cameroon rendezte: ", moviesDirectedByJames);

// 10 - Keresse ki a 'Fantasy' kaland (Adventure) zsáner kategóriájjú filmeket.
List<Movie> fantasyMovies = movies.Where(x => x.MajorGenre?.ToLower() == "adventure").ToList();
WriteToConsole("\nFantasy zsánerű filmek: ", fantasyMovies);

// 11 - Kik rendeztek akció (Action) filmeket és mikor?
List<ActionMovies> actionMovies = movies.Where(m => m.MajorGenre?.ToLower() == "action" && m.Director != null)
									  .GroupBy(m => m.Director)
									  .Select(m => new ActionMovies
									  {
										  Director = m.Key,
										  ReleaseYears = m.Select(m => m.ReleaseDate).ToList()
									  })
									  .ToList();
Console.WriteLine($"\nRendezők, kik akciófilmeket rendeztek + dátum: {actionMovies}");


// 12 - 'Paramount Pictures' horror filmjeinek cime?
List<string> horrorMoviesByParamount = movies.Where(m => m.MajorGenre?.ToLower() == "horror" && m.Distributor?.ToLower() == "paramount pictures")
											 .Select(m => m.Title)
											 .ToList();
Console.WriteLine($"\nParamount Pictures horror filmjeinek címe: {horrorMoviesByParamount}");


// 13 - Van-e olyan film melyet 'Tom Crusie' rendezett?
bool anyFilmByTomCruise = movies.Any(m => m.Director?.ToLower() == "tom cruise");
Console.WriteLine($"\n{(anyFilmByTomCruise ? "Van" : "Nincs")} olyan film, melyet Tom Cruise rendezett");


// 14 - A 'Little Miss Sunshine' filme mekkora össz bevételt hozott?
long? incomeOfLittleMissSunshine = movies.Where(m => m.Title?.ToLower() == "little miss sunshine")
									   .Sum(m => m.USDVDSales + m.WorldwideGross + m.USGross);
Console.WriteLine($"\nA Little Miss Sunshine ennyi bevételt hozott összesen: {incomeOfLittleMissSunshine}");


// 15 - Hány olyan film van amely az IMDB-n 6 feletti osztályzatot ért el és a 'Rotten Tomatoes'-n pedig legalább 25-t?
int numberOfMoviesWithHigherRating = movies.Where(m => m.IMDBRating > 6 && m.RottenTomatoesRating >= 25)
										  .Count();
Console.WriteLine($"\nFilmek, melyek IMDB-n 6 felettit, Rotten Tomatoes-on pedig legalább 25-öt értek el: {numberOfMoviesWithHigherRating}");


// 16 - 'Michael Bay' filmjei átlagban mekkora bevételt hoztak?
double averageIncomeOFBaysMovies = movies.Where(m => m.Director?.ToLower() == "michael bay")
											.Average(m => m.USDVDSales ?? 0 + m.USGross ?? 0 + m.WorldwideGross ?? 0);
Console.WriteLine($"\nMichael Bay filmjeinek átlagbevétele: {averageIncomeOFBaysMovies}");



// 17 - Melyek azok a 'Michael Bay' a 'Walt Disney Pictures' által forgalmazott fimek melyek legalább 150min hosszúak.
List<Movie> moviesMadeByBayAndDisney = movies.Where(m => m.Director?.ToLower() == "michael bay" &&
														 m.Distributor?.ToLower() == "walt disney pictures" &&
														 m.RunningTime >= 150).ToList();
WriteToConsole("\nMichael Bay Walt Disney Pictures átlag forgalmazott filmjei, melyek min. 150 perc hosszúak: ", moviesMadeByBayAndDisney);



// 18 - Listázza ki a forgalmazókat úgy, hogy mindegyik csak egyszer jelenjen meg!
List<string> distributors = movies.Where(m => m.Distributor != null)
								   .Select(m => m.Distributor)
								   .Distinct()
								   .ToList();
WriteStringToConsole("\nForgalmazók: ", distributors);


// 19 - Rendezze a filmeket az 'IMDB Votes' szerint  növekvő sorrendbe.
List<Movie> orderedListByIMDBVotes = movies.OrderBy(m => m.IMDBVotes).ToList();
WriteToConsole("\nFilmek IMDB szavazatok alapján sorba rendezve: ", orderedListByIMDBVotes);


// 20 - Rendezze a filmeket címük szerint csökkenő sorrendbe!
List<Movie> orderedListByFilmNames = movies.OrderByDescending(m => m.Title).ToList();
WriteToConsole("\nFilmek név szerint csökkenő sorrendben (AKA Z-A): ", orderedListByFilmNames);


// 21 - Melyek azok a filmek melyek hossza meghaladja a 120 percet?
List<Movie> moviesWithMoreThan120MinRunningTime = movies.Where(m => m.RunningTime > 120).ToList();
WriteToConsole("\nFilmek, melyek hosszabbak, mint 120 perc: ", moviesWithMoreThan120MinRunningTime);


// 22 - Hány film jelent meg december hónapban?
int numberOfMoviesReleasedInDecember = movies.Count(m => m.ReleaseDate.Month == 12);
Console.WriteLine($"\nDecemberben ennyi film jelent meg: {numberOfMoviesReleasedInDecember}");

// 23 - Egyes besorolásokban (Rating) hány film található?
List<NumberFilmsGroupedByRating> numberOfFilmsInRatings = movies.Where(m => m.Rating != null)
																.GroupBy(m => m.Rating)
																.Select(m => new NumberFilmsGroupedByRating
																{
																	RatingName = m.Key,
																	NumberOfFilms = m.Count()
																}).ToList();
WriteNumberFilmsGroupedByRatingToConsole("\nEnnyi film található egyes besorolásokban: ", numberOfFilmsInRatings);


// 24 - Keresse ki azokat a filmeket melyeket 'Ron Howard' rendezett a 2000 években, 'PG-13' bsorolású, lagalább 80 perc hosszú és az IMDB legalább 6.5 átlagot ért el.
List<Movie> moviesMadeByRonHoward = movies.Where(m => m.Director?.ToLower() == "ron howard" &&
													  m.ReleaseDate.Year >= 2000 && m.ReleaseDate.Year < 2010 &&
													  m.Rating?.ToLower() == "pg-13" &&
													  m.RunningTime >= 80 && m.IMDBRating >= 6.5
													  ).ToList();
WriteToConsole("\nFilmek, melyeket 'Ron Howard' rendezett a 2000-es években, 'PG-13' besorolású, legalább 80 perc hosszúak és az IMDB-en legalább 6.5 átlagot értek el: ", moviesMadeByRonHoward);


// 25 - A 'Lionsgate' kiadónál kik rendeztek filmeket?
List<string> directorsDirectedMovieForLionsgate = movies.Where(m => m.Distributor?.ToLower() == "lionsgate" && m.Director != null)
														.Select(m => m.Director).Distinct().ToList();
WriteStringToConsole("Ezek az emberek rendeztek filmeket a Lionsgatenél: ", directorsDirectedMovieForLionsgate);


// 26 - Az 'Universal' forgalmazó átlagban mennyit kültött film forgatására?
double averageBudgetOfUniversalFilms = movies.Where(m => m.Distributor?.ToLower() == "universal")
												.Average(m => m.ProductionBudget ?? 0);
Console.WriteLine($"\nAz Universal forgalmazó átlagban ennyit költött film forgatásra: {averageBudgetOfUniversalFilms}");


// 27 - Az 'IMDB Votes' alapján melyek azok a filmek, melyeket többen értékeltek min 30 000-n?
List<Movie> moviesWithMoreThan30000Votes = movies.Where(m => m.IMDBVotes >= 30000).ToList();
WriteToConsole("\nFilmek, melyek több, mint 30000 szavazatot kaptak IMDB-n: ", moviesWithMoreThan30000Votes);


// 28 - Az 'American Pie' című filmnek hány része van?
int numberOfEpisodesOfAmericanPie = movies.Where(m => m.Title != null)
										  .Count(m => m.Title.ToLower().Contains("american pie"));
Console.WriteLine($"\nAz American Pie című filmnek ennyi része van: {numberOfEpisodesOfAmericanPie}");


// 29 - Van-e olyan film melynek a címében szerepel a 'fantasy' szó és a zsánere 'Adventure'?
bool anyAventureFilmsWithfantasyInTitle = movies.Where(m => m.Title != null)
						.Any(m => m.MajorGenre?.ToLower() == "adventure" &&
								  m.Title.ToLower().Contains("fantasy"));
Console.WriteLine($"\n{(anyAventureFilmsWithfantasyInTitle ? "Van" : "Nincs")} olyan film, aminek szerepel a címében a 'fantasy' szó és a zsánere 'Adventure'");


// 30 - Átlagban hányan szavaztak az IMDB-n?
double averageNumberOfVotesOnIMDB = movies.Average(m => m.IMDBVotes ?? 0);
Console.WriteLine($"\nÁtlagosan ennyien szavaztak az IMDB-n: {averageNumberOfVotesOnIMDB}");


// 31 - Kik rendeztek a 'Warner Bros.' forgalmazónál dráma filmeket 1970 és 1975 közt melyre az 'IMDB Votes' alapján többen szavaztak az átlagnál?
List<string> directorsWhoDirectedMovieForWarner = movies.Where(m => m.Distributor?.ToLower() == "warner bros." &&
																	m.Director != null && m.MajorGenre?.ToLower() == "drama" &&
																	m.ReleaseDate.Year >= 1970 && m.ReleaseDate.Year <= 1975 &&
																	m.IMDBVotes > averageNumberOfVotesOnIMDB)
														 .Select(m => m.Director).ToList();
WriteStringToConsole("Rendezők, akik rendeztek a 'Warner Bros.' forgalmazónál dráma filmeket 1970 és 1975 közt melyre az 'IMDB Votes' alapján többen szavaztak az átlagnál: ", directorsWhoDirectedMovieForWarner);


// 32 - Van e olyan film amely karácsony napján jelent meg?
bool anyFilmsReleasdOnChristmasDay = movies.Any(m => m.ReleaseDate.Month == 12 && m.ReleaseDate.Day == 25);
Console.WriteLine($"\n{(anyFilmsReleasdOnChristmasDay ? "Van" : "Nincs")} olyan film, ami pont karácsony napján jelent meg");


// 33 - 'Spider-Man' című filmek USA-ban mekkora bevételt hoztak?
long spiderManMoviesIncomeInTheUSA = movies.Where(m => m.Title != null && m.Title.ToLower().Contains("spider man"))
		.Sum(m => m.USDVDSales ?? 0 + m.USGross ?? 0);
Console.WriteLine($"\nA Spider-Man filmek az USA-ban ennyit hoztak: {spiderManMoviesIncomeInTheUSA}");


// 34 - Keresse ki  szuperhősös (Super Hero) filmek címeit.
List<string> superHeroMoviesTitles = movies.Where(m => m.CreativeType?.ToLower() == "super hero")
											.Select(m => m.Title).ToList();
WriteStringToConsole("\nFilmek, melyek a címük alapján szuperhősökről szólnak (contains a 'super hero'): ", superHeroMoviesTitles);