using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;
public abstract class BaseRepo<TDomain, TData> : PagedRepo<TDomain, TData>, IRepo<TDomain> 
    where TDomain : class, IEntity
    where TData : class, IEntity{
	protected BaseRepo(DbContext c, DbSet<TData> s) : base(c, s) { }
    public virtual string selectTextField => nameof(IEntity.ID);
    public IEnumerable<dynamic> SelectList => new SelectList(set.AsNoTracking(), nameof(IEntity.ID), selectTextField);
}
