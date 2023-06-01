using Contoso.Data.Base;

namespace Contoso.Domain.BaseRepos;
public interface IOrderedRepo<T> : IFilteredRepo<T> where T : IEntity { }