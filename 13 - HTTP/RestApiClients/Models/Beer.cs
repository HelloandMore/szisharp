using System.Text;

namespace Models;

public class Beer
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("price")]
    public string Price { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("image")]
    public string Image {  get; set; }

    [JsonPropertyName("rating")]
    public Rating Rating { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Id: {this.Id}");
        sb.AppendLine($"Name: {this.Name}");
        sb.AppendLine($"Price: {this.Price}");
        sb.AppendLine($"Image: {this.Image}");
        sb.AppendLine($"Rating:");
        sb.AppendLine($"\tAverage: {this.Rating?.Average}");
        sb.AppendLine($"\tReviews: {this.Rating?.Reviews}");

        return sb.ToString();
    }
}
