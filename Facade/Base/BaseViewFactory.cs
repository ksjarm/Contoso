using Contoso.Aids;
using Contoso.Data.Base;
using Contoso.Domain.Base;

namespace Contoso.Facade.Base;
public abstract class BaseViewFactory<TData, TObject, TView>
        where TData : BaseData, new() where TObject : BaseEntity<TData> where TView : BaseView, new() {
    public virtual TObject Create(TView v) {
        var d = new TData();
        if (v is not null) copy(v, d);
        return toObject(d);
    }
    public virtual TView Create(TObject o, bool load = false) => Create(o?.data);
    public virtual TView Create(TData d) {
        var v = new TView();
        if (d is not null) copy(d, v);
        return v;
    }
    protected internal abstract TObject toObject(TData d);
    protected internal virtual void copy(TView v, TData d) => Copy.Members(v, d);
    protected internal virtual void copy(TData d, TView v) => Copy.Members(d, v);
}