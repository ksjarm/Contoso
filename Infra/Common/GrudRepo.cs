using Contoso.Aids;
using Contoso.Data;
using Contoso.Domain.BaseRepos;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;
public abstract class GrudRepo<TDomain, TData> : IGrudRepo<TDomain>
    where TDomain : class, IEntity
    where TData : class, IEntity {
    protected internal DbContext db { get; }
    protected internal DbSet<TData> set { get; }
    protected internal IQueryable<TData> sql { get; set; }
    protected GrudRepo(DbContext c, DbSet<TData> s) {
        db = c;
        set = s;
    }
    public bool Add(TDomain obj) => Safe.Run(() => add(toData(obj)));
    public async Task<bool> AddAsync(TDomain obj) => await Safe.RunAsync(() => addAsync(toData(obj)));
    public bool Delete(int id) => Safe.Run(() => delete(id));
    public async Task<bool> DeleteAsync(int id) => await Safe.RunAsync(() => deleteAsync(id));
    public IEnumerable<TDomain> Get() => GetAsync().GetAwaiter().GetResult();
    public async Task<IEnumerable<TDomain>> GetAsync() => (await getAsync()).Select(toDomain);
    public async Task<IEnumerable<TData>> getAsync() {
        sql = createSQL();
        sql = addAggregates(sql);
        return await runSQLAsync();
    }
    protected internal virtual IQueryable<TData> addAggregates(IQueryable<TData> sql) => sql;
    public async virtual Task<IEnumerable<TDomain>> GetAsync(string sortOrder, int pageIndex, string searchString) => await GetAsync();
    public TDomain Get(int? id) => toDomain(get(id));
    public async Task<TDomain> GetAsync(int? id) => toDomain(await getAsync(id));
    public bool Update(TDomain obj) => Safe.Run(() => update(toData(obj)));
    public async Task<bool> UpdateAsync(TDomain obj) => await Safe.RunAsync(() => updateAsync(toData(obj)));
    internal bool add(TData obj) => addAsync(obj).GetAwaiter().GetResult();
    internal bool delete(int id) => deleteAsync(id).GetAwaiter().GetResult();
    internal TData get(int? id) => getAsync(id).GetAwaiter().GetResult();
    internal bool update(TData obj) => updateAsync(obj).GetAwaiter().GetResult();
    internal async Task<TData> getAsync(int? id) {
        if (id is null) return null;
        if (set is null) return null;
        return await addAggregates(set).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }
    internal async Task<bool> addAsync(TData obj) {
        await set.AddAsync(obj);
        await db.SaveChangesAsync();
        return true;
    }
    internal async Task<bool> deleteAsync(int id) {
        var x = toData(Get(id));
        if (x is null) return false;
        db.Entry(x).State = EntityState.Deleted;
        await db.SaveChangesAsync();
        return true;
    }
    internal async Task<bool> updateAsync(TData d) {
        if (!set.Any(x => x.ID == d.ID)) return Add(toDomain(d));
        set.Update(d);
        await db.SaveChangesAsync();
        return true;
    }
    protected internal virtual IQueryable<TData> createSQL() => from s in set select s;
    protected internal virtual IEnumerable<TData> runSQL() => runSQLAsync().GetAwaiter().GetResult();
    protected internal virtual async Task<IEnumerable<TData>> runSQLAsync() => await sql.AsNoTracking().ToListAsync();

    protected abstract TDomain toDomain(TData d);
    protected abstract TData toData(TDomain o);
}