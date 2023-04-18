using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class OfficeAssignmentController : SchoolController<IOfficeAssignmentsRepo, OfficeAssignment> {
    public OfficeAssignmentController(SchoolContext c, IOfficeAssignmentsRepo r) : base (c, r) { }
}
