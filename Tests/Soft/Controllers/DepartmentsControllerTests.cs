using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;
using Contoso.Facade;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class DepartmentsControllerTests : 
    BaseTests<DepartmentsController, BaseController<IDepartmentsRepo, Department, DepartmentView>> {
    protected override DepartmentsController createObj() => new();
}
