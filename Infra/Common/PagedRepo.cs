using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;

public class PagedRepo<T> : OrderedRepo<T>, IPagedRepo<T> where T : class, IEntity {
	public PagedRepo(DbContext? c, DbSet<T>? s) : base(c, s) { }
}
