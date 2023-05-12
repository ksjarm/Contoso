using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public sealed class Course : NamedEntity<CourseData> {
    public Course() : this(null) { }
    public Course(CourseData d) : base(d) { }
    public int Number => getValue(data.Number);
    public int Credits => getValue(data.Credits);
    public int DepartmentID => getValue(data.DepartmentID);
    public Lazy<Department> Department => new(GetRepo.Item<IDepartmentsRepo, Department>(DepartmentID));
    public Lazy<IEnumerable<Enrollment>> Enrollments 
        => new(GetRepo.List<IEnrollmentsRepo, Enrollment>(x => x.CourseID == ID));
    public Lazy<IEnumerable<CourseAssignment>> CourseAssignments
        => new(GetRepo.List<ICourseAssignmentsRepo, CourseAssignment>(x => x.CourseID == ID));
}