using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public sealed class Course : NewNamedEntity<CourseData> {
    public Course() : this(null) { }
    public Course(CourseData d) : base(d) { }
    public int Number => getValue(data.Number);
    public int Credits => getValue(data.Credits);
    public int DepartmentID => getValue(data.DepartmentID);
    public Department Department => GetRepo.Item<IDepartmentsRepo, Department>(DepartmentID);
    public IEnumerable<Enrollment> Enrollments 
        => GetRepo.List<IEnrollmentsRepo, Enrollment>(x => x.CourseID == ID);
    public IEnumerable<CourseAssignment> CourseAssignments 
        => GetRepo.List<ICourseAssignmentsRepo, CourseAssignment>(x => x.CourseID == ID);
}
