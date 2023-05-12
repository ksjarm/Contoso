using Contoso.Data;
using Contoso.Domain.Base;
using Contoso.Domain.BaseRepos;
using Contoso.Domain.Repos;

namespace Contoso.Domain;
public sealed class CourseAssignment : DescribedEntity<CourseAssignmentData> {
    public CourseAssignment() : this(null) { }
    public CourseAssignment(CourseAssignmentData d) : base(d) { }
    public int InstructorID => getValue(data.InstructorID);
    public int CourseID => getValue(data.CourseID);
    public Lazy<Instructor> Instructor => new(GetRepo.Item<IInstructorsRepo, Instructor>(InstructorID));
    public Lazy<Course> Course => new(GetRepo.Item<ICoursesRepo, Course>(CourseID));
}