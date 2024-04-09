namespace Solution.Services;

public class DigimonServiceService : BaseService<Digimon, int>, IDigimonServiceService<Digimon, int>
{
    public DigimonServiceService() : base()
    {
        this.Items = ReadDataFromUrlAsync("https://digimon-api.vercel.app/api/digimon").Result;
    }

    public override Digimon Create(Digimon model)
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

    public override ICollection<Digimon> GetAll()
    {
        return Items;
    }

    public override Digimon GetById(int id)
    {
        var item = Items.Find(x => x.Id == id) ?? throw new Exception("Item not found!");
        return item;
    }

    public override void Update(Digimon model)
    {
        var item = GetById(model.Id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
        Items.Insert(index, model);
    }
}
