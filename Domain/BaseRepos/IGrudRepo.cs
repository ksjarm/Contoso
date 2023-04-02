using Contoso.Data;

namespace Contoso.Domain.BaseRepos;

public interface IGrudRepo<T> where T : IEntity
{
	IEnumerator<T> Get();
	T? Get(int? id);
	bool Update(T obj);
	bool Add(T obj);
	bool Delete(int id);
}
