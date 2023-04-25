using Contoso.Domain;
using Contoso.Domain.Repos;
using Contoso.Infra;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Soft.Controllers;
public class OfficeAssignmentController : BaseController<IOfficeAssignmentsRepo, OfficeAssignment> {
    private readonly SchoolContext context;
    public OfficeAssignmentController(SchoolContext c, IOfficeAssignmentsRepo r = null) : base(r) => context = c;
}
