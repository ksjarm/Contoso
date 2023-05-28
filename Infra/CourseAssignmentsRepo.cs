using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class CourseAssignmentsRepo : BaseRepo<CourseAssignment, CourseAssignmentData>, ICourseAssignmentsRepo {
    public CourseAssignmentsRepo(SchoolContext c) : base(c, c.CourseAssignments) { }
    protected internal override IQueryable<CourseAssignmentData> addFilter(IQueryable<CourseAssignmentData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.InstructorID.ToString().Contains(v) ||
               x.CourseID.ToString().Contains(v) ||
               x.Description.Contains(v) ||
               x.ValidFrom.ToString().Contains(v) ||
               x.ValidTo.ToString().Contains(v));
    }
    protected override CourseAssignmentData toData(CourseAssignment o) => o.data;
    protected override CourseAssignment toDomain(CourseAssignmentData d) => new(d);
}