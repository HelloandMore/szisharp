namespace Solution.Common.Interfaces;

public interface IBeerService<T, Tkey> : IBaseService<T, Tkey> where T : class
{
}
