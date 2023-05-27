using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class InstructorViewFactory : PersonViewFactory<InstructorData, Instructor, InstructorView> {
    protected internal override Instructor toObject(InstructorData d) => new(d);
    public override InstructorView Create(Instructor o, bool load = false) {
        var v = Create(o?.data);
        v.FullName = o?.FullName;
        if (!load) return v;
        var f = new CourseViewFactory();
        v.Office = o?.OfficeAssignment?.Value?.Location;
        v.Courses = o?.CourseAssignments?.Value?.Select(c => f.Create(c?.Course?.Value));
        return v;
    }
}
