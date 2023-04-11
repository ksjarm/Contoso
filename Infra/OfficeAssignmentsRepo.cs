using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class OfficeAssignmentsRepo : BaseRepo<OfficeAssignment>, IOfficeAssignmentsRepo {
    public OfficeAssignmentsRepo(SchoolContext c) : base(c, c.OfficeAssignments) { }
}
