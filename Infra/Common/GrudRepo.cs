using Contoso.Aids;
using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;

public abstract class GrudRepo<T> : IGrudRepo<T> where T : class, IEntity {
	protected internal DbContext db { get; }
	protected internal DbSet<T> set { get; }
    protected internal IQueryable<T> sql { get; set;  }
	protected GrudRepo(DbContext c, DbSet<T> s) {
		db = c;
		set = s;
	}
	public bool Add(T obj) => Safe.Run(() => add(obj));
	public bool Delete(int id) => Safe.Run(() => delete(id));
    public IEnumerable<T> Get() {
        sql = сreateSQL();
        return runSQL();
    }

    protected internal virtual IEnumerable<T> runSQL() => sql.AsNoTracking().ToList();
    protected internal virtual IQueryable<T> сreateSQL() => from s in set select s;

    public T? Get(int? id) => (id is not null)? set?.Find(id): null;
	public bool Update(T obj) => Safe.Run(() =>  update(obj));
    internal bool add(T obj) {
        set.Add(obj);
        db.SaveChanges();
        return true;
    }
    internal bool delete(int id) {
        var x = Get(id);
        if (x is null) return false;
        set.Remove(x);
        db.SaveChanges();
        return true;
    }
    internal bool update(T obj) {
        if (!set.Any(x => x.ID == obj.ID)) return Add(obj);
        set.Update(obj);
        db.SaveChanges();
        return true;
    }
}
