using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


List<Movie> movies = LoadData();
WriteToConsole($"Data ({movies.Count})", movies);

// 1 - Hány film adatát dolgozzuk fel?
int amountOfMovies = movies.Count;
Console.WriteLine($"\nEnnyi film van az adatbázisban: {amountOfMovies}");

// 2 - Mekkora bevételt hoztak a filmek Amerikában?
long sumOfUSRevenue = movies.Where(x => x.USGross != null)
                           .Sum(x => x.USGross.Value);
long sumOfUSRevenue2 = movies.Sum(x => x.USGross ?? 0);

Console.WriteLine($"\nEnnyi bevételt hoztak összesen a filmek az USAban: {sumOfUSRevenue}");
Console.WriteLine($"Másik megoldás: {sumOfUSRevenue2}");

// 3 - Mekkora bevételt hoztak a filmek Világszerte?
long sumOfWorldwideRev = movies.Sum(x => x.WorldwideGross ?? 0);
Console.WriteLine($"\nVilágszerte ennyi bevételt hoztak a filmek: {sumOfWorldwideRev}");

// 4 - Hány film jelent meg az 1990-es években?
int countOfMoviesProducedIn1990s = movies.Where(x => x.ReleaseDate.Year > 1990 && x.ReleaseDate.Year < 2000).Count();

// 5 - Hányan szavaztak összessen az IMDB-n?
long countOfIMDBVotes = movies.Where(x => x.IMDBVotes.HasValue).Sum(x => x.IMDBVotes.Value);

// 6 - Hányan szavaztak átlagossan az IMDB-n?
double sumOfIMDBVotes = movies.Average(x => x.IMDBVotes ?? 0);

// 7 - A filmek  világszerte átlagban mennyit hoztak a konyhára?
double averageWWRevenue = movies.Average(x => x.WorldwideGross ?? 0);

// 8 - Hány filmet rendezett 'Christopher Nolan' ?
int sumByChristopherNolan = movies.Count(x => x.Director?.ToLower() == "christopher nolan");

// 9 - Melyik filmeket rendezte 'James Cameron'?
List<Movie> moviesByJamesCameron = movies.Where(x => x.Director?.ToLower() == "james cameron").ToList();

// 10 - Keresse ki a 'Fantasy' kaland (Adventure) zsáner kategóriájjú filmeket.
List<Movie> fantasyMovies = movies.Where(x => x.CreativeType?.ToLower() == "Fantasy" && x.MajorGenre?.ToLower() == "adventure").ToList();

// 11 - Kik rendeztek akció (Action) filmeket és mikor?
List<ActionDirectorsAndWhen> actionDirectorsandWhen = movies.Where(x => x.MajorGenre == "Action").Where(x => x.Director != null).GroupBy(x => x.Director)
                                                            .Select(x => new ActionDirectorsAndWhen
                                                            {
                                                                name = x.Key,
                                                                times = x.Select(x => x.ReleaseDate).ToList(),
                                                            }).ToList();

// 12 - 'Paramount Pictures' horror filmjeinek cime?
List<string> nameOfParamountHorrorMovies = movies.Where(x => x.MajorGenre.ToLower() == "horror" && x.Distributor.ToLower() == "paramount pictures").ToList();

// 13 - Van-e olyan film melyet 'Tom Crusie' rendezett?

// 14 - A 'Little Miss Sunshine' filme mekkora össz bevételt hozott?

// 15 - Hány olyan film van amely az IMDB-n 6 feletti osztályzatot ért el és a 'Rotten Tomatoes'-n pedig legalább 25-t?

// 16 - 'Michael Bay' filmjei átlagban mekkora bevételt hoztak?

// 17 - Melyek azok a 'Michael Bay' a 'Walt Disney Pictures' által forgalmazott fimek melyek legalább 150min hosszúak.

// 18 - Listázza ki a forgalmazókat úgy, hogy mindegyik csak egyszer jelenjen meg!

// 19 - Rendezze a filmeket az 'IMDB Votes' szerint  növekvő sorrendbe.

// 20 - Rendezze a filmeket címük szerint csökkenő sorrendbe!

// 21 - Melyek azok a filmek melyek hossza meghaladja a 120 percet?

// 22 - Hány film jelent meg december hónapban?

// 23 - Egyes besorolásokban (Rating) hány film található?

// 24 - Keresse ki azokat a filmeket melyeket 'Ron Howard' rendezett a 2000 években, 'PG-13' bsorolású, lagalább 80 perc hosszú és az IMDB legalább 6.5 átlagot ért el.

// 25 - A 'Lionsgate' kiadónál kik rendeztek filmeket?

// 26 - Az 'Universal' forgalmazó átlagban mennyit kültött film forgatására?

// 27 - Az 'IMDB Votes' alapján melyek azok a filmek, melyeket többen értékeltek min 30 000-n?

// 28 - Az 'American Pie' című filmnek hány része van?

// 29 - Van-e olyan film melynek a címében szerepel a 'fantasy' szó és a zsánere 'Adventure'?

// 30 - Átlagban hányan szavaztak az IMDB-n?

// 31 - Kik rendeztek a 'Warner Bros.' forgalmazónál dráma filmeket 1970 és 1975 közt melyre az 'IMDB Votes' alapján többen szavaztak az átlagnál?

// 32 - Van e olyan film amely karácsony napján jelent meg?

// 33 - 'Spider-Man' című filmek USA-ban mekkora bevételt hoztak?

// 34 - Keresse ki  szuperhősös (Super Hero) filmek címeit.