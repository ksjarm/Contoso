using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class DepartmentViewFactory : BaseViewFactory<DepartmentData, Department, DepartmentView> {
    protected internal override Department toObject(DepartmentData d) => new(d);
    public override DepartmentView Create(Department o, bool load = false) {
        var v = Create(o?.data);
        if (!load) return v;
        v.InstructorName = o?.Administrator?.Value?.FullName;
        return v;
    }
}