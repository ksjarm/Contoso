using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;

public abstract class FilteredRepo<T> 
	: GrudRepo<T>, IFilteredRepo<T> where T : class, IEntity {
	protected FilteredRepo(DbContext? c, DbSet<T>? s) : base(c, s) { }
    public string? CurrentFilter { get; set; }

    public override async Task<IEnumerable<T>> GetAsync(string sortOrder, int pageIndex, string searchString) {
        CurrentFilter = searchString;
        return await base.GetAsync(sortOrder, pageIndex, searchString);
    }
    protected internal override IQueryable<T> сreateSQL() {
        var s = base.сreateSQL();
		return addFilter(s);
    }
    protected internal virtual IQueryable<T> addFilter(IQueryable<T> s) => s;
}
