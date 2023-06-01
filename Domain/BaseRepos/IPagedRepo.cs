using Contoso.Data.Base;

namespace Contoso.Domain.BaseRepos;
public interface IPagedRepo<T> : IOrderedRepo<T> where T : IEntity {
    public int PageIndex { get; set; }
    public int TotalPages { get; }
    public int PageSize { get; set; }
}