using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class ParentsControllerTests : 
    BaseTests<ParentsController, BaseController<IParentsRepo, Parent, ParentView>> {
    protected override ParentsController createObj() => new();
}