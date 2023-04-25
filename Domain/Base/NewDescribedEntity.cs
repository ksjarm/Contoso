using Contoso.Data.Base;

namespace Contoso.Domain.Base;
public abstract class NewDescribedEntity<TData> : NewBaseEntity<TData> where TData: DescribedData, new() {
    protected NewDescribedEntity(TData d) : base(d) {}
    public string Description => getValue(data.Description);
}

