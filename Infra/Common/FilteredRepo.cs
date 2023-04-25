using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;
public abstract class FilteredRepo<TDomain, TData> : GrudRepo<TDomain, TData>, IFilteredRepo<TDomain>
    where TDomain : class, IEntity
    where TData : class, IEntity {
    protected FilteredRepo(DbContext c, DbSet<TData> s) : base(c, s) { }
    public string? CurrentFilter { get; set; }
    public override async Task<IEnumerable<TDomain>> GetAsync(string sortOrder, int pageIndex, string searchString) {
        CurrentFilter = searchString;
        return await base.GetAsync(sortOrder, pageIndex, searchString);
    }
    protected internal override IQueryable<TData> createSQL() {
        var s = base.createSQL();
        return addFilter(s);
    }
    protected internal virtual IQueryable<TData> addFilter(IQueryable<TData> s) => s;
}