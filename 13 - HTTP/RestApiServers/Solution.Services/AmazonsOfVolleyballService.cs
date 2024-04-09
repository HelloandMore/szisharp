namespace Solution.Services;

public class AmazonsOfVolleyballService : BaseService<Player, int>, IAmazonsOfVolleyballService<Player, int>
{
    public AmazonsOfVolleyballService() : base()
    {
        this.Items = ReadDataFromJson("amazons_of_volleyball.json");
    }

    public override Player Create(Player model)
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

    public override ICollection<Player> GetAll()
    {
        return Items;
    }

    public override Player GetById(int id)
    {
        var item = Items.Find(x => x.Id == id) ?? throw new Exception("Item not found!");
        return item;
    }

    public override void Update(Player model)
    {
        var item = GetById(model.Id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
        Items.Insert(index, model);
    }
}
