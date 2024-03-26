namespace Solution.Common.Interfaces;

public interface IBaseService<T, TKey> where T : class
{
    void Create(T model);
    T GetById(TKey id);
    void Update(T model);
    void Delete(TKey id);
    ICollection<T> GetAll();
}
