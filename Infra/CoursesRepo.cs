using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class CoursesRepo : BaseRepo<Course>, ICoursesRepo {
    public CoursesRepo(SchoolContext c) : base(c, c.Courses) { }
    public override string selectTextField => nameof(Course.Name);
    protected internal override IQueryable<Course> addFilter(IQueryable<Course> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.Credits.ToString().Contains(v) ||
               x.Number.ToString().Contains(v));
    }
	protected internal override IQueryable<Course> addAggregates(IQueryable<Course> sql)
		=> sql.Include(e => e.Department);
}
