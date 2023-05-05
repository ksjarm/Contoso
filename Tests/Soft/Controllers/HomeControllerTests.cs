using Contoso.Soft.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class HomeControllerTests : BaseTests<HomeController, Controller> {
    protected override HomeController createObj() => new(null);
}
