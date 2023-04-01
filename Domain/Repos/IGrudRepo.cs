namespace Contoso.Domain.Repos;

public interface IGrudRepo<T> where T : IEntity
{
    IEnumerator<T> Get();
    T Get(int id);
    bool Update(T obj);
    bool Add(T obj);
    bool Delete(int id);
}
