using Contoso.Aids;
using Contoso.Data.Base;
using Contoso.Domain.Base;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public abstract class BaseViewFactory<TData, TObject, TView>
        where TData : BaseData, new()
        where TObject : NewBaseEntity<TData>
        where TView : BaseView, new() {
    public virtual TObject Create(TView v) {
        var d = new TData();
        if (v is not null) Copy.Members(v, d);
        return toObject(d);
    }
    public virtual TView Create(TObject o) => Create(o?.data);
    public virtual TView Create(TData d) {
        var v = new TView();
        if (d is not null) Copy.Members(d, v);
        return v;
    }
    protected internal abstract TObject toObject(TData d);
}