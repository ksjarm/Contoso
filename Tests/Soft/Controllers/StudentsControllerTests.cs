using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Tests.Soft.Controllers;
public class StudentsControllerTests : 
    BaseTests<StudentsController, BaseController<IStudentsRepo, Student>> {
    protected override StudentsController createObj() => new(null);
}
