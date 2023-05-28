using Contoso.Data.Base;

namespace Contoso.Domain.Base;
public abstract class NamedEntity<TData> : DescribedEntity<TData> where TData : NamedData, new() {
    protected NamedEntity(TData d) : base(d) { }
    public string Code => getValue(data?.Code);
    public string Name => getValue(data?.Name);
}

