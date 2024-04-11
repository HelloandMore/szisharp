namespace Models;

public class Rating
{
    [JsonPropertyName("average")]
    public double Average { get; set; }

    [JsonPropertyName("reviews")]
    public int Reviews { get; set; }
}
