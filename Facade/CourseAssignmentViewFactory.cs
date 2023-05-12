using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class CourseAssignmentViewFactory : BaseViewFactory<CourseAssignmentData, CourseAssignment, CourseAssignmentView> {
    protected internal override CourseAssignment toObject(CourseAssignmentData d) => new(d);
    public override CourseAssignmentView Create(CourseAssignment o, bool load = false) {
        var v = Create(o?.data);
        if (!load) return v;
        v.InstructorName = o?.Instructor?.Value?.FullName;
        v.CourseName = o?.Course?.Value?.Name;
        return v;
    }
}