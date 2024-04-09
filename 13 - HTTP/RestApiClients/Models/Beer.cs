using System.Text;

namespace Models
{
	public class Beer
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("price")]
		public string Price { get; set; }

		[JsonPropertyName("image")]
		public string Image { get; set; }

		[JsonPropertyName("rating")]
		public string Rating { get; set; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Id: {this.Id}");
			sb.AppendLine($"Name: {this.Name}");
			sb.AppendLine($"Price: {this.Price}");
			sb.AppendLine($"Image: {this.Image}");
			sb.AppendLine($"Rating: ");
			sb.AppendLine($"\t- Average: {this.Rating?.Average}");
			sb.AppendLine($"\t- Reviews: {this.Rating?.Reviews}");

			return sb.ToString();
		}
	}

}
