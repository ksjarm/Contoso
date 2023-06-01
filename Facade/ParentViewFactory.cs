using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class ParentViewFactory : PersonViewFactory<ParentData, Parent, ParentView> {
    protected internal override Parent toObject(ParentData d) => new(d);
    public override ParentView Create(Parent o, bool load = false) {
        var v = Create(o?.data);
        v.FullName = o?.FullName;
		if (!load) return v;
		var p = new StudentViewFactory();
		v.Relationships = o?.Relationships?.Value?.Select(x => p.Create(x?.Student?.Value));
		return v;
    }
}