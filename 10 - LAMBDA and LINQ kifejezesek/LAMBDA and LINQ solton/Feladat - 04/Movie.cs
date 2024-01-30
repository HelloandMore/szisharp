using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Feladat___04
{
    public class Movie
    {
        /// <summary>
        /// Cím
        /// </summary>
        [JsonPropertyName("Title")]
        public string Title {get; set; }

        /// <summary>
        /// USA bevétel
        /// </summary>
        [JsonPropertyName("US Gross")]
        public int? USGross {get; set; }

        /// <summary>
        /// Bevétel a világban
        /// </summary>
        [JsonPropertyName("Worldwide Gross")]
        public long? WorldwideGross {get; set; }

        /// <summary>
        /// USA eladott DVD száma
        /// </summary>
        [JsonPropertyName("US DVD Sales")]
        public int? USDVDSales {get; set; }

        /// <summary>
        /// Film elkészítésének költsége
        /// </summary>
        [JsonPropertyName("Production Budget")]
        public int? ProductionBudget { get; set; }

        /// <summary>
        /// Megjelenés dátuma
        /// </summary>
        [JsonPropertyName("Release Date")]
        public DateTime ReleaseDate {get; set; }

        /// <summary>
        /// Besorolás
        /// </summary>
        [JsonPropertyName("Rating")]
        public string Rating {get; set; }

        /// <summary>
        /// Film hossza percekben
        /// </summary>
        [JsonPropertyName("Running Time min")]
        public int? RunningTime { get; set; }

        /// <summary>
        /// Forgalmazó
        /// </summary>
        [JsonPropertyName("Distributor")]
        public string Distributor{get; set; }

        /// <summary>
        /// Forrás
        /// </summary>
        [JsonPropertyName("Source")]
        public string Source{get; set; }

        /// <summary>
        /// Zsáner
        /// </summary>
        [JsonPropertyName("Major Genre")]
        public string MajorGenre {get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Creative Type")]
        public string  CreativeType{get; set; }

        /// <summary>
        /// Rendező
        /// </summary>
        [JsonPropertyName("Director")]
        public string Director { get; set; }

        /// <summary>
        /// Rotten Tomatoes Értékelés
        /// </summary>
        [JsonPropertyName("Rotten Tomatoes Rating")]
        public double? RottenTomatoesRating {get; set; }

        /// <summary>
        /// IMDB Értékelés
        /// </summary>
        [JsonPropertyName("IMDB Rating")]
        public double? IMDBRating {get; set; }

        /// <summary>
        /// IMDB értékelők száma
        /// </summary>
        [JsonPropertyName("IMDB Votes")]
        public int? IMDBVotes {get; set; }

        public Movie()
        {
            USGross ??= new Random().Next(1000000, 1000001);
            ProductionBudget ??= new Random().Next(1000000, 2000001);
            RunningTime ??= new Random().Next(60, 210);
            RottenTomatoesRating ??= new Random().Next() + new Random().Next(0, 10);
            IMDBRating ??= new Random().Next() + new Random().Next(0, 10);
            IMDBVotes ??= new Random().Next(1000, 100000);
            WorldwideGross = new Random().Next(1000000, 10000001);
        }

        public override string ToString()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };

            options.Converters.Add(new DateFormatConverter());

            return JsonSerializer.Serialize(this, options);
        }
    }
}
