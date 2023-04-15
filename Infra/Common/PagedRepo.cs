using Contoso.Aids;
using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;
public class PagedRepo<T> : OrderedRepo<T>, IPagedRepo<T> where T : class, IEntity {
	public PagedRepo(DbContext? c, DbSet<T>? s) : base(c, s) { }
    public int TotalPages => Safe.Run(() => (int) Math.Ceiling(countPages), 0);
    internal double countPages => (double)set.Count() / PageSize;
    public int PageIndex { get; set; }
    public int PageSize { get; set; } = 3;
    public int skippedItemsCount => PageSize * PageIndex;
    public override async Task<IEnumerable<T>> GetAsync(string sortOrder, int pageIndex) {
        PageIndex = pageIndex;
        return await base.GetAsync(sortOrder, pageIndex);
    }
    protected internal override IQueryable<T> сreateSQL() {
        var s = base.сreateSQL();
		return addSkipAndTake(s);
    }
    private IQueryable<T> addSkipAndTake(IQueryable<T> s) => s.Skip(skippedItemsCount).Take(PageSize);
}
