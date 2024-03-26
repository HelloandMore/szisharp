namespace Solution.Common.Interfaces;

public interface IGameService<T, Tkey> : IBaseService<T, Tkey> where T : class
{
}
