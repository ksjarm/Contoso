using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class CourseAssignmentsRepo : BaseRepo<CourseAssignment>, ICourseAssignmentsRepo {
    public CourseAssignmentsRepo(SchoolContext c) : base(c, c.CourseAssignments) { }
    protected internal override IQueryable<CourseAssignment> addFilter(IQueryable<CourseAssignment> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.InstructorID.ToString().Contains(v) ||
               x.CourseID.ToString().Contains(v));
    }
    protected internal override IQueryable<CourseAssignment> addAggregates(IQueryable<CourseAssignment> sql) 
        => sql.Include(x => x.Instructor).Include(x => x.Course);
}
