namespace Solution.Services;

public class GameServiceService : BaseService<Game, int>, IGameService<Game, int>
{
    public GameServiceService() : base()
    {
        this.Items = ReadDataFromUrlAsync("https://www.mmobomb.com/api1/games").Result;
    }

    public override Game Create(Game model)
    {
        model.Id = Items.Last().Id + 1;
        Items.Add(model);

        return model;
    }

    public override void Delete(int id)
    {
        var item = GetById(id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
    }

    public override ICollection<Game> GetAll()
    {
        return Items;
    }

    public override Game GetById(int id)
    {
        var item = Items.Find(x => x.Id == id) ?? throw new Exception("Item not found!");
        return item;
    }

    public override void Update(Game model)
    {
        var item = GetById(model.Id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
        Items.Insert(index, model);
    }
}
