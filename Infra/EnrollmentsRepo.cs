using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class EnrollmentsRepo : BaseRepo<Enrollment, EnrollmentData>, IEnrollmentsRepo {
    public EnrollmentsRepo(SchoolContext c) : base(c, c.Enrollments) { }
    protected internal override IQueryable<EnrollmentData> addFilter(IQueryable<EnrollmentData> s) {
        var v = CurrentFilter;
        return string.IsNullOrWhiteSpace(v) ? base.addFilter(s) :
             s.Where(x => x.StudentID.ToString().Contains(v) ||
               x.CourseID.ToString().Contains(v) ||
               x.Description.Contains(v) ||
               x.ValidFrom.ToString().Contains(v) ||
               x.ValidTo.ToString().Contains(v));
    }
    protected override EnrollmentData toData(Enrollment o) => o?.Data;
    protected override Enrollment toDomain(EnrollmentData d) => new(d);
}
