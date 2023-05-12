using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class OfficeAssignmentViewFactory : BaseViewFactory<OfficeAssignmentData, OfficeAssignment, OfficeAssignmentView> {
    protected internal override OfficeAssignment toObject(OfficeAssignmentData d) => new(d);
    public override OfficeAssignmentView Create(OfficeAssignment o, bool load = false) {
        var v = Create(o?.data);
        if (!load) return v;
        v.InstructorName = o?.Instructor?.Value?.FullName;
        return v;
    }
}