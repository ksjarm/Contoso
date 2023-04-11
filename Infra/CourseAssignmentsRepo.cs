using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class CourseAssignmentsRepo : BaseRepo<CourseAssignment>, ICourseAssignmentsRepo {
    public CourseAssignmentsRepo(SchoolContext c) : base(c, c.CourseAssignments) { }
}
