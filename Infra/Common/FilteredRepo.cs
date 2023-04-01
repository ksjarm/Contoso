using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;

public abstract class FilteredRepo<T> 
	: GrudRepo<T>, IFilteredRepo<T> where T : class, IEntity {
	protected FilteredRepo(DbContext? c, DbSet<T>? s) : base(c, s) { }
}
