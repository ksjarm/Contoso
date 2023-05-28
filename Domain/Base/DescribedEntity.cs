using Contoso.Data.Base;

namespace Contoso.Domain.Base;
public abstract class DescribedEntity<TData> : BaseEntity<TData> where TData : DescribedData, new() {
    protected DescribedEntity(TData d) : base(d) {}
    public string Description => getValue(data.Description);
}