using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra.Common;

namespace Contoso.Infra;
public class OfficeAssignmentsRepo : BaseRepo<OfficeAssignment, OfficeAssignment>, IOfficeAssignmentsRepo {
    public OfficeAssignmentsRepo(SchoolContext c) : base(c, c.OfficeAssignments) { }
    protected override OfficeAssignment toDomain(OfficeAssignment d) => d;

    protected override OfficeAssignment toData(OfficeAssignment o) => o;
}
