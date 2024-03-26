namespace Solution.Services;

public class BeerService : BaseService<Beer, int>, IBeerService<Beer, int>
{
    public BeerService() : base()
    {
        this.Items = ReadDataFromUrlAsync("https://api.sampleapis.com/beers/ale").Result;
    }

    public override void Create(Beer model)
    {
        model.Id = Items.Last().Id + 1;
        Items.Add(model);
    }

    public override void Delete(int id)
    {
        var item = GetById(id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
    }

    public override ICollection<Beer> GetAll()
    {
        return Items;
    }

    public override Beer GetById(int id)
    {
        var item = Items.Find(x => x.Id == id) ?? throw new Exception("Item not found!");
        return item;
    }

    public override void Update(Beer model)
    {
        var item = GetById(model.Id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
        Items.Insert(index, item);
    }
}
