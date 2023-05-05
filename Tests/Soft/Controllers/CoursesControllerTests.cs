using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Tests.Soft.Controllers;
public class CoursesControllerTests : 
    BaseTests<CoursesController, BaseController<ICoursesRepo, Course, CourseView>> {
    protected override CoursesController createObj() => new();
}