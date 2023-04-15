using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class CoursesRepo : BaseRepo<Course>, ICoursesRepo {
    public CoursesRepo(SchoolContext c) : base(c, c.Courses) { }
    protected internal override IQueryable<Course> addFilter(IQueryable<Course> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.Credits.ToString().Contains(v) ||
               x.Number.ToString().Contains(v));
    }
}
