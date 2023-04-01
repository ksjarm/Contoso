using Contoso.Data;

namespace Contoso.Domain.BaseRepos;

public interface IPagedRepo<T> : IOrderedRepo<T> where T : IEntity
{

}
