using Contoso.Aids;
using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;
public abstract class GrudRepo<T> : IGrudRepo<T> where T : class, IEntity {
	protected internal DbContext db { get; }
	protected internal DbSet<T> set { get; }
    protected internal IQueryable<T> sql { get; set; }
	protected GrudRepo(DbContext c, DbSet<T> s) {
		db = c;
		set = s;
	}
	public bool Add(T obj) => Safe.Run(() => add(obj));
    public bool Delete(int id) => Safe.Run(() => delete(id));
    public IEnumerable<T> Get() => GetAsync().GetAwaiter().GetResult();
    public T? Get(int? id) => get(id);
    public bool Update(T obj) => Safe.Run(() => update(obj));
    public async Task<bool> AddAsync(T obj) => await Safe.RunAsync(() => addAsync(obj));
    public async Task<bool> DeleteAsync(int id) => await Safe.RunAsync(() => deleteAsync(id));
    public async Task<IEnumerable<T>> GetAsync() {
        sql = сreateSQL();
        sql = addAggregates(sql);
        return await runSQLAsync();
    }
	protected internal virtual IQueryable<T> addAggregates(IQueryable<T> sql) => sql;
	public async virtual Task<IEnumerable<T>> GetAsync(string sortOrder, int pageIndex, string searchString) => await GetAsync();
    public async Task<T?> GetAsync(int? id) => await getAsync(id);
    public async Task<bool> UpdateAsync(T obj) => await Safe.RunAsync(() => updateAsync(obj));
    internal bool add(T obj) => addAsync(obj).GetAwaiter().GetResult();
    internal bool delete(int id) => deleteAsync(id).GetAwaiter().GetResult();
    internal bool update(T obj) => updateAsync(obj).GetAwaiter().GetResult();
    internal T? get(int? id) => getAsync(id).GetAwaiter().GetResult();
    internal async Task<bool> addAsync(T obj) {
        await set.AddAsync(obj);
        await db.SaveChangesAsync();
        return true;
    }
    internal async Task<bool> deleteAsync(int id) {
        var x = Get(id);
        if (x is null) return false;
        db.Entry(x).State = EntityState.Deleted;
        await db.SaveChangesAsync();
        return true;
    }
    internal async Task<bool> updateAsync(T obj) {
        if (!set.Any(x => x.ID == obj.ID)) return Add(obj);
        set.Update(obj);
        await db.SaveChangesAsync();
        return true;
    }
    internal async Task<T?> getAsync(int? id) {
        if (id == null) return null;
        if (set == null) return null;
        return await addAggregates(set).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }
    protected internal virtual IQueryable<T> сreateSQL() => from s in set select s;
    protected internal virtual IEnumerable<T> runSQL() => runSQLAsync().GetAwaiter().GetResult();
    protected internal virtual async Task<IEnumerable<T>> runSQLAsync() => await sql.AsNoTracking().ToListAsync();
}
