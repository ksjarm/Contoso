using Contoso.Aids;
using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Contoso.Infra.Common;
public abstract class OrderedRepo<T> : FilteredRepo<T>, IOrderedRepo<T> where T : class, IEntity {
    internal static string descendingStr => "_desc";
    internal string? propertyName => SortOrder?.Replace(descendingStr, string.Empty);
    internal PropertyInfo? propertyInfo => Safe.Run(() => typeof(T).GetProperty(propertyName ?? string.Empty));
    public string SortOrder { get; set; }
	protected OrderedRepo(DbContext? c, DbSet<T>? s) : base(c, s) { }
	public override async Task<IEnumerable<T>> GetAsync(string sortOrder, int pageIndex) {
		SortOrder = sortOrder;
		return await base.GetAsync(sortOrder, pageIndex);
	}
    protected internal override IQueryable<T> сreateSQL() {
        var s = base.сreateSQL();
        var keySelector = createKeySelector();
		return addOrderBy(s, keySelector);
    }
    private Expression<Func<T, object>>? createKeySelector() {
        var pi = propertyInfo;
        if (pi is null) return null;
        var param = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(param, pi);
        var body = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<T, object>>(body, param);
    }
    private IQueryable<T> addOrderBy(IQueryable<T> s, Expression<Func<T, object>>? keySelector) {
        if (keySelector is null) return s;
        if (isDescending) return s.OrderByDescending(keySelector);
		else return s.OrderBy(keySelector);
    }
    internal bool isDescending => SortOrder.EndsWith(descendingStr);
}
