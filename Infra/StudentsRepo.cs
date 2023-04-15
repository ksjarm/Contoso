using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class StudentsRepo : BaseRepo<Student>, IStudentsRepo {
	public StudentsRepo(SchoolContext c) : base(c, c.Students) { }
    protected internal override IQueryable<Student> addFilter(IQueryable<Student> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.Name.Contains(v) ||
               x.FirstMidName.Contains(v) ||
               x.EnrollmentDate.ToString().Contains(v));
    }
}