using Contoso.Data;
using Contoso.Domain;
using Contoso.Facade.Base;

namespace Contoso.Facade;
public sealed class StudentViewFactory : PersonViewFactory<StudentData, Student, StudentView> {
    protected internal override Student toObject(StudentData d) => new(d);
    public override StudentView Create(Student o, bool load = false) {
        var v = Create(o?.data);
        v.FullName = o?.FullName;
        if (!load) return v;
        var f = new CourseViewFactory();
        v.Enrollments = o?.Enrollments?.Value?.Select(x => f.Create(x?.Course?.Value));
        return v;
    }
}