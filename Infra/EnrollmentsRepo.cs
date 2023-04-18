using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infra;
public class EnrollmentsRepo : BaseRepo<Enrollment>, IEnrollmentsRepo {
    public EnrollmentsRepo(SchoolContext c) : base(c, c.Enrollments) { }
	protected internal override IQueryable<Enrollment> сreateSQL() => addAggregates(base.сreateSQL());
	protected internal override IQueryable<Enrollment> addAggregates(IQueryable<Enrollment> sql)
		=> sql.Include(e => e.Course).Include(e => e.Student);
}
