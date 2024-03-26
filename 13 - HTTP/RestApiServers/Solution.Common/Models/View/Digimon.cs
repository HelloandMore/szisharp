namespace Solution.Common.Models.View;

public class Digimon: IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    public string Level { get; set; }
}
