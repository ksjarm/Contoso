using Contoso.Data.Base;

namespace Contoso.Domain.BaseRepos;
public interface IRepo<T> : IPagedRepo<T> where T : IEntity {
    public IEnumerable<dynamic> SelectList { get; }
    Task<IEnumerable<dynamic>> SelectItems(string searchString, string id);
    Task<dynamic> SelectItem(string id);
}