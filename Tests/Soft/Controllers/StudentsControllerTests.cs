using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class StudentsControllerTests : 
    BaseTests<StudentsController, BaseController<IStudentsRepo, Student, StudentView>> {
    protected override StudentsController createObj() => new();
}