namespace Solution.Services;

public abstract class BaseService<T, TKey> : IBaseService<T, TKey> where T : class
{
    protected List<T> Items { get; set; } = new List<T>();

    public abstract T Create(T model);

    public abstract void Delete(TKey id);

    public abstract ICollection<T> GetAll();

    public abstract T GetById(TKey id);

    public abstract void Update(T model);

    protected List<T> ReadDataFromJson(string fileName)
    {
        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "bin\\Debug\\net8.0\\Sources", fileName);

            var json = File.ReadAllText(path);

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(!string.IsNullOrWhiteSpace(json) ? json : string.Empty));

            var jsonData = JsonSerializer.Deserialize<List<T>>(stream);

            return jsonData ?? [];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    protected void SaveDataAsJson(string fileName, List<T> data)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "bin\\Debug\\net8.0\\Output", fileName);

        var json = JsonSerializer.Serialize(data);

        File.WriteAllText(path, json);
    }

    protected async Task<List<T>> ReadDataFromUrlAsync(string url)
    {
        var jsonData = await url.GetJsonAsync<List<T>>();

        foreach ((IEntity<int> value, int index) data in jsonData.Select((T value, int index) => (value, index)))
        {
            data.value.Id = data.index;
        }

        return jsonData;
    }
}
