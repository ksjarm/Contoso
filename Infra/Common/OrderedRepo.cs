using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;

public abstract class OrderedRepo<T> 
	: FilteredRepo<T>, IOrderedRepo<T> where T : class, IEntity {
	protected OrderedRepo(DbContext? c, DbSet<T>? s) : base(c, s) { }
}
