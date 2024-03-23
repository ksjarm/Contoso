using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class OfficeAssignmentsControllerTests : 
    BaseTests<OfficeAssignmentsController, BaseController<IOfficeAssignmentsRepo, OfficeAssignment, OfficeAssignmentView>> {
    protected override OfficeAssignmentsController createObj() => new();
}