using System.Text.Encodings.Web;
using System.Text.Json;

namespace Feladat___01
{
    public class Player
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Játékos neve
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Kép link
        /// </summary>
        public string ImageLink { get; set; }
        
        /// <summary>
        /// Klub
        /// </summary>
        public string Club { get; set; }
        
        /// <summary>
        /// Poszt
        /// </summary>
        public string Position  { get; set; }
        
        /// <summary>
        /// Születés dátuma
        /// </summary>
        public string Birthday { get; set; }
        
        /// <summary>
        /// Súly
        /// </summary>
        public int Weight { get; set; }
        
        /// <summary>
        /// Magasság
        /// </summary>
        public double Height { get; set; }

        public Player()
        {
        }

        public Player(int id, string name, string imageLink, string club, string position, string birthday, int weight, double height)
        {
            Id = id;
            Name = name;
            ImageLink = imageLink;
            Club = club;
            Position = position;
            Birthday = birthday;
            Weight = weight;
            Height = height;
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
