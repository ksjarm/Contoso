using Contoso.Aids;
using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Contoso.Infra.Common;
public abstract class OrderedRepo<TDomain, TData> : FilteredRepo<TDomain, TData>, IOrderedRepo<TDomain>
    where TDomain : class, IEntity where TData : class, IEntity {
    public string SortOrder { get; set; }
    internal static string descendingStr => "_desc";
    internal string propertyName => SortOrder?.Replace(descendingStr, string.Empty);
    internal PropertyInfo propertyInfo => Safe.Run(() => typeof(TData).GetProperty(propertyName ?? string.Empty));
    protected OrderedRepo(DbContext c, DbSet<TData> s) : base(c, s) { }
    public override async Task<IEnumerable<TDomain>> GetAsync(string sortOrder, int pageIndex, string searchString) {
        SortOrder = sortOrder;
        return await base.GetAsync(sortOrder, pageIndex, searchString);
    }
    protected internal override IQueryable<TData> createSQL() {
        var s = base.createSQL();
        var keySelector = createKeySelector();
        return addOrderBy(s, keySelector);
    }
    private Expression<Func<TData, object>> createKeySelector() {
        var pi = propertyInfo;
        if (pi is null) return null;
        var param = Expression.Parameter(typeof(TData), "x");
        var property = Expression.Property(param, pi);
        var body = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<TData, object>>(body, param);
    }
    internal IQueryable<TData> addOrderBy(IQueryable<TData> s, Expression<Func<TData, object>> keySelector) {
        if (keySelector is null) return s;
        if (isDescending) return s.OrderByDescending(keySelector);
        else return s.OrderBy(keySelector);
    }
    internal bool isDescending => SortOrder.EndsWith(descendingStr);
}