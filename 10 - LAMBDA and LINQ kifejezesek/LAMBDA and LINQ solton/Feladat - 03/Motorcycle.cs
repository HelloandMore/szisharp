using System.Text.Encodings.Web;
using System.Text.Json;

namespace Feladat___03
{
    public class Motorcycle
    {
        /// <summary>
        /// Gyártó
        /// </summary>
        public string Brand { get; set; }
        
        /// <summary>
        /// Moell
        /// </summary>
        public string Model { get; set; }
        
        /// <summary>
        /// Becenév
        /// </summary>
        public string Nickname { get; set; } = string.Empty;
        
        /// <summary>
        /// Megjelenési év
        /// </summary>
        public int ReleaseYear { get; set; }
        
        /// <summary>
        /// Köbcenti
        /// </summary>
        public int Cubic { get; set; }
        
        /// <summary>
        /// Teljesítmény kW-ban
        /// </summary>
        public int KW { get; set; }
        
        /// <summary>
        /// Kategória
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// Max sebesség
        /// </summary>
        public int TopSpeed { get; set; }

        public Motorcycle()
        {
        }

        public Motorcycle(string brand, string model, string nickname, int releaseYear, int cubic, int kW, string category, int topSpeed)
        {
            Brand = brand;
            Model = model;
            Nickname = nickname;
            ReleaseYear = releaseYear;
            Cubic = cubic;
            KW = kW;
            Category = category;
            TopSpeed = topSpeed;
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
