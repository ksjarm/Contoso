using Contoso.Data;

namespace Contoso.Domain.BaseRepos;
public interface IRepo<T> : IPagedRepo<T> where T : IEntity {
    public IEnumerable<dynamic> SelectList { get; }

}
