using Contoso.Data;

namespace Contoso.Domain.BaseRepos;
public interface IGrudRepo<T> where T : IEntity {
	IEnumerable<T> Get();
	T Get(int? id);
	bool Update(T obj);
	bool Add(T obj);
	bool Delete(int id);

    Task<IEnumerable<T>> GetAsync();
    Task<IEnumerable<T>> GetAsync(string sortOrder, int pageIndex, string searchString);
    Task<T?> GetAsync(int? id);
    Task<bool> UpdateAsync(T obj);
    Task<bool> AddAsync(T obj);
    Task<bool> DeleteAsync(int id);
}
