namespace Solution.Common.Models.View;

public class Champion : IEntity<int>
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("lore")]
    public string Lore { get; set; }

    [JsonPropertyName("tags")]
    public string Tags { get; set; }

    [JsonPropertyName("champion_abilities")]
    public List<ChampionAbilitiy> ChampionAbilities { get; set; } = new List<ChampionAbilitiy>();

    [JsonPropertyName("champion_stats")]
    public List<ChampionStat> ChampionStats = new List<ChampionStat>();

    [JsonPropertyName("champion_tips")]
    public List<ChampionTip> ChampionTips = new List<ChampionTip>();
}

public class ChampionAbilitiy
{
    [JsonPropertyName("id")]
    [JsonIgnore]
    public int Id { get; set; }

    [JsonPropertyName("Champion")]
    [JsonIgnore]
    public int Champion { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("effect")]
    public string Effect { get; set; }

    [JsonPropertyName("cost")]
    public string Cost { get; set; }

    [JsonPropertyName("range")]
    public int Range { get; set; }
}

public class ChampionStat
{
    [JsonPropertyName("champion")]
    [JsonIgnore]
    public int Champion { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("modifier_per_level")]
    public double ModifierPerLevel { get; set; }
}

public class ChampionTip
{
    [JsonPropertyName("id")]
    [JsonIgnore]
    public int Id { get; set; }

    [JsonPropertyName("champion")]
    public int Champion { get; set; }

    [JsonPropertyName("tip")]
    public string Tip { get; set; }
}
