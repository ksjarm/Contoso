using Contoso.Aids;
using Contoso.Data.Base;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;
public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData>, IPagedRepo<TDomain>
    where TDomain : class, IEntity where TData : class, IEntity {
    protected PagedRepo(DbContext c, DbSet<TData> s) : base(c, s) { }
    public int TotalPages => Safe.Run(() => (int)Math.Ceiling(countPages), 0);
    internal double countPages => (double)set.Count() / PageSize;
    public int PageIndex { get; set; }
    public int PageSize { get; set; } = 10;
    public int skippedItemsCount => PageSize * PageIndex;
    public override async Task<IEnumerable<TDomain>> GetAsync(string sortOrder, int pageIndex, string searchString) {
        PageIndex = pageIndex;
        return await base.GetAsync(sortOrder, pageIndex, searchString);
    }
    protected internal override IQueryable<TData> createSQL() {
        var s = base.createSQL();
        return PageSize == -1 ? s : addSkipAndTake(s);
    }
    private IQueryable<TData> addSkipAndTake(IQueryable<TData> s) => s.Skip(skippedItemsCount).Take(PageSize);
}