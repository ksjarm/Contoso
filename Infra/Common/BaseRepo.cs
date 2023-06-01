using Contoso.Data.Base;
using Contoso.Domain.BaseRepos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra.Common;
public abstract class BaseRepo<TDomain, TData> : PagedRepo<TDomain, TData>, IRepo<TDomain>
    where TDomain : class, IEntity where TData : class, IEntity {

    private int itemId;
    protected BaseRepo(DbContext c, DbSet<TData> s) : base(c, s) { }
    public virtual string selectTextField => nameof(IEntity.ID);
    public IEnumerable<dynamic> SelectList => new SelectList(set.AsNoTracking(), nameof(IEntity.ID), selectTextField);
    public async Task<IEnumerable<dynamic>> SelectItems(string searchString, string selectedItemId) {
        PageIndex = 0;
        SortOrder = selectTextField;
        CurrentFilter = searchString;
        var l = await getSelected(selectedItemId, await getAsync());
        return l;
    }
    public async Task<dynamic> SelectItem(string id) {
        var l = await getSelected(id);
        return l.FirstOrDefault();
    }
    private async Task<SelectList> getSelected(string id, IEnumerable<TData> list = null) {
        var l = toList(list);
        var d = await getItem(id);
        if (!alreadyInList(d, l)) l.Add(d);
        return new SelectList(l, nameof(IEntity.ID), selectTextField, itemId);
    }
    private static bool alreadyInList(TData d, List<TData> l) => d is null || l.Any(x => x.ID == d.ID);
    private static List<TData> toList(IEnumerable<TData> list) => (list is null) ? new List<TData>() : list.ToList();
    private async Task<TData> getItem(string id) => int.TryParse(id, out itemId) ? await getAsync(itemId) : null;
}
