using Contoso.Data;
using Contoso.Domain.Base;

namespace Contoso.Domain;
public class Course : NewNamedEntity<CourseData> {
    public Course(CourseData d) : base(d) { }
    public int Number => getValue(data.Number);
    public int Credits => getValue(data.Credits);
    public int DepartmentID => getValue(data.DepartmentID);
    public Department Department { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<CourseAssignment> CourseAssignments { get; set; }
}
