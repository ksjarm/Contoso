using Contoso.Data.Base;
using Contoso.Aids;

namespace Contoso.Domain.Base; 
public abstract class AnEntity<TData> where TData : BaseData, new() {
    protected internal TData data { get; set; }
    protected AnEntity(TData d) => data = d;
    protected internal T getValue<T>(T v) => v ?? default; 
    public TData Data { get {
            if (data is null) return null;
            var d = new TData();
            Copy.Members(data, d);
            return d;
        }
    }
}