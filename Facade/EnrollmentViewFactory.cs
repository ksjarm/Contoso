using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class EnrollmentViewFactory : BaseViewFactory<EnrollmentData, Enrollment, EnrollmentView> {
    protected internal override Enrollment toObject(EnrollmentData d) => new(d);
    public override EnrollmentView Create(Enrollment o, bool load = false) {
        var v = Create(o?.data);
        if (!load) return v;
        v.StudentName = o?.Student?.Value?.FullName;
        v.CourseName = o?.Course?.Value?.Name;
        return v;
    }
}