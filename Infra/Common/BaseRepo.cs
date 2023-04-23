using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;
public abstract class BaseRepo<T> : PagedRepo<T>, IRepo<T> where T : class, IEntity {
	protected BaseRepo(DbContext? c, DbSet<T>? s) : base(c, s) { }
    public virtual string selectTextField => nameof(IEntity.ID);
    public IEnumerable<dynamic> SelectList => new SelectList(set.AsNoTracking(), nameof(IEntity.ID), selectTextField);
}
