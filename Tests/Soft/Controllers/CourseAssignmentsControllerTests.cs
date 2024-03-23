using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class CourseAssignmentsControllerTests : 
    BaseTests<CourseAssignmentsController, BaseController<ICourseAssignmentsRepo, CourseAssignment, CourseAssignmentView>> {
    protected override CourseAssignmentsController createObj() => new();
}