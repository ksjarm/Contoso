using Contoso.Data.Base;

namespace Contoso.Domain.Base;
public abstract class NewNamedEntity<TData> : NewDescribedEntity<TData> where TData: NamedData, new() {
    protected NewNamedEntity(TData d) : base(d) { }
    public string Code => getValue(data?.Code);
    public string Name => getValue(data?.Name);
}

