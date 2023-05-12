using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Domain.Base;
public abstract class BaseEntity<TData> : AnEntity<TData>, IEntity where TData : BaseData, new() {
    protected BaseEntity(TData d) : base(d) { }
    public int ID => getValue(data.ID);
    public DateTime ValidFrom => getValue(data.ValidFrom);
    public DateTime ValidTo => getValue(data.ValidTo);
    //[Timestamp] public byte[] RowVersion => getValue(data.Token);
}