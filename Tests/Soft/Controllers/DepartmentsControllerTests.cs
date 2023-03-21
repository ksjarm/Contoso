using Contoso.Soft.Controllers;
using Microsoft.AspNetCore.Mvc;
using Tests.Domain;

namespace Tests.Soft.Controllers {
    public class DepartmentsControllerTests : BaseTests<DepartmentsController, Controller> {
        protected override DepartmentsController createObj() => new(null);
    }
}
