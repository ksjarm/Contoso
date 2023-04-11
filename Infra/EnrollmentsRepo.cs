using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class EnrollmentsRepo : BaseRepo<Enrollment>, IEnrollmentsRepo {
    public EnrollmentsRepo(SchoolContext c) : base(c, c.Enrollments) { }
}
