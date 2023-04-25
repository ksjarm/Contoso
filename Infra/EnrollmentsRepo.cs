using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class EnrollmentsRepo : BaseRepo<Enrollment, Enrollment>, IEnrollmentsRepo {
    public EnrollmentsRepo(SchoolContext c) : base(c, c.Enrollments) { }
    protected internal override IQueryable<Enrollment> createSQL() => addAggregates(base.createSQL());
    protected internal override IQueryable<Enrollment> addAggregates(IQueryable<Enrollment> sql)
		=> sql.Include(e => e.Course).Include(e => e.Student);
    protected override Enrollment toDomain(Enrollment d) => d;

    protected override Enrollment toData(Enrollment o) => o;
}
