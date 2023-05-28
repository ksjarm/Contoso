using Contoso.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Contoso.Domain.BaseRepos;
public static class GetRepo {
    internal static IServiceProvider provider;
    public static TRepo Instance<TRepo, TItem>() where TRepo : class, IRepo<TItem> where TItem : IEntity
            => provider?.CreateScope()?.ServiceProvider?.GetRequiredService<TRepo>();
    public static void SetServiceProvider(IServiceProvider p) => provider = p;
    internal static TItem Item<TRepo, TItem>(int? id) where TRepo : class, IRepo<TItem> where TItem : IEntity
            => Instance<TRepo, TItem>().Get(id);
    internal static IEnumerable<TItem> List<TRepo, TItem>(Func<TItem, bool> predicate) 
        where TRepo : class, IRepo<TItem> where TItem : IEntity {
        
        var r = Instance<TRepo, TItem>();
        r.PageSize = -1;
        return r.Get().Where(predicate);
    }
}
