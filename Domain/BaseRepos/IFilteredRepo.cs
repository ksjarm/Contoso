using Contoso.Data;

namespace Contoso.Domain.BaseRepos;
public interface IFilteredRepo<T> : IGrudRepo<T> where T : IEntity {
    public string? CurrentFilter { get; set; }
}
