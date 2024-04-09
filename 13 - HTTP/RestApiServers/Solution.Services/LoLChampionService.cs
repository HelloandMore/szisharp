namespace Solution.Services;

public class LoLChampionService : BaseService<Champion, int>, ILoLChampionService<Champion, int>
{
    public LoLChampionService() : base()
    {
        this.Items = ReadDataFromJson("lol.json");
    }

    public override Champion Create(Champion model)
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

    public override ICollection<Champion> GetAll()
    {
        return Items;
    }

    public override Champion GetById(int id)
    {
        var item = Items.Find(x => x.Id == id) ?? throw new Exception("Item not found!");
        return item;
    }

    public override void Update(Champion model)
    {
        var item = GetById(model.Id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
        Items.Insert(index, model);
    }
}
