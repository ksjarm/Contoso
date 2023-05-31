using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class RelationshipViewFactory : BaseViewFactory<RelationshipData, Relationship, RelationshipView> {
    protected internal override Relationship toObject(RelationshipData d) => new(d);
    public override RelationshipView Create(Relationship o, bool load = false) {
        var v = Create(o?.data);
        if (!load) return v;
        v.StudentName = o?.Student?.Value?.FullName;
        v.ParentName = o?.Parent?.Value?.FullName;
        return v;
    }
}