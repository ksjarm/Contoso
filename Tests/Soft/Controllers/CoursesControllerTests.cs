using Contoso.Soft.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Soft.Controllers
{
    public class CoursesControllerTests : BaseTests<CoursesController, Controller> {
        protected override CoursesController createObj() => new(null);
    }
}