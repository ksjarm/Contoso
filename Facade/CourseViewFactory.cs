using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class CourseViewFactory : BaseViewFactory<CourseData, Course, CourseView> {
    protected internal override Course toObject(CourseData d) => new(d);
    public override CourseView Create(Course o, bool load = false) {
        var v = Create(o?.data);
        if (!load) return v;
        v.DepartmentName = o?.Department.Value?.Name;
        return v;
    }
}