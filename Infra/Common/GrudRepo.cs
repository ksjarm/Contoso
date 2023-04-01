using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;

public abstract class GrudRepo<T> : IGrudRepo<T> where T : class, IEntity {
	protected internal DbContext? db { get; }
	protected internal DbSet<T>? set { get; }
	protected GrudRepo(DbContext? c, DbSet<T>? s) {
		db = c;
		set = s;
	}
	public bool Add(T obj) => throw new NotImplementedException();
	public bool Delete(int id) {
		try {
			if ((db is null) || (set is null)) return false;
			var x = set.Find(id);
			if (x is null) return false;
			set.Remove(x);
			db.SaveChanges();
			return true;
		}
		catch (Exception e) {
			return false;
		}
	}
	public IEnumerator<T> Get() => throw new NotImplementedException();
	public T Get(int id) => throw new NotImplementedException();
	public bool Update(T obj) => throw new NotImplementedException();
}
