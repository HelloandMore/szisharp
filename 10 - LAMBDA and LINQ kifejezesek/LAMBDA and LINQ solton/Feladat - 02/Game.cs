using System.Text.Encodings.Web;
using System.Text.Json;

namespace Feladat___02
{
    public class Game
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Cím
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Előnézeti kép
        /// </summary>
        public string Thumbnail { get; set; }
        
        /// <summary>
        /// Rövid leírás
        /// </summary>
        public string Short_description { get; set; }
        
        /// <summary>
        /// Játek web címe
        /// </summary>
        public string Game_url { get; set; }
        
        /// <summary>
        /// Zsáner
        /// </summary>
        public string Genre { get; set; }
        
        /// <summary>
        /// Platform
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Forgalmazó
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Fejlesztő
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Megejelnés dátuma
        /// </summary>
        public string Release_date { get; set; }
        public string Profile_url { get; set; }

        public Game()
        {
        }

        public Game(int id, string title, string thumbnail, string short_description, string game_url, string genre, string platform, string publisher, string developer, string release_date, string profile_url)
        {
            Id = id;
            Title = title;
            Thumbnail = thumbnail;
            Short_description = short_description;
            Game_url = game_url;
            Genre = genre;
            Platform = platform;
            Publisher = publisher;
            Developer = developer;
            Release_date = release_date;
            Profile_url = profile_url;
        }

        public override string ToString()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };

            return JsonSerializer.Serialize(this, options);
        }
    }
}
