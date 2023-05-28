using Contoso.Data;

namespace Contoso.Domain.BaseRepos;
public interface IOrderedRepo<T> : IFilteredRepo<T> where T : IEntity { }