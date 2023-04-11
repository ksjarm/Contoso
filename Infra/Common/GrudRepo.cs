using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;

public abstract class GrudRepo<T> : IGrudRepo<T> where T : class, IEntity {
	protected internal DbContext db { get; }
	protected internal DbSet<T> set { get; }
	protected GrudRepo(DbContext c, DbSet<T> s) {
		db = c;
		set = s;
	}
	public bool Add(T obj) {
		try {
			set.Add(obj);
			db.SaveChanges();
			return true;
		} catch (Exception e) {
			return false;
		}
	}
	public bool Delete(int id) {
		try {
			var x = Get(id);
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
	public T? Get(int? id) => (id is not null)? set?.Find(id): null;
	public bool Update(T obj) {
		try {
			if (!set.Any(x => x.ID == obj.ID)) return Add(obj);
			set.Update(obj);
			db.SaveChanges();
			return true;
		} catch (Exception e) {
			return false;
		}
	}
}
