using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class EnrollmentsControllerTests : 
    BaseTests<EnrollmentsController, BaseController<IEnrollmentsRepo, Enrollment, EnrollmentView>> {
    protected override EnrollmentsController createObj() => new();
}