using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class CoursesRepo : BaseRepo<Course, CourseData>, ICoursesRepo {
    public CoursesRepo(SchoolContext c) : base(c, c.Courses) { }
    public override string selectTextField => nameof(CourseData.Name);
    protected internal override IQueryable<CourseData> addFilter(IQueryable<CourseData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.Credits.ToString().Contains(v) ||
               x.Number.ToString().Contains(v));
    }
    protected override CourseData toData(Course o) => o.data;
    protected override Course toDomain(CourseData d) => new (d);
}