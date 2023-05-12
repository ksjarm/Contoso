using Contoso.Domain;

namespace Contoso.Facade.Common;
public class InstructorIndexView
{
    public IEnumerable<Instructor> Instructors { get; set; }
    public IEnumerable<Course> Courses { get; set; }
    public IEnumerable<Enrollment> Enrollments { get; set; }
}