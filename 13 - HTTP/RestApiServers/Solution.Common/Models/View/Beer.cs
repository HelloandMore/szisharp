namespace Solution.Common.Models.View;

public class Beer : IEntity<int>
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("price")]
    public string Price { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("rating")]
    public Rating Rating { get; set; }
}

public class Rating
{
    [JsonPropertyName("average")]
    public double Average { get; set; }

    [JsonPropertyName("reviews")]
    public int Reviews { get; set; }
}