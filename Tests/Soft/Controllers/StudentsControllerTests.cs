using Contoso.Soft.Controllers;
using Microsoft.AspNetCore.Mvc;
using Tests.Domain;

namespace Tests.Soft.Controllers {
    public class StudentsControllerTests : BaseTests<StudentsController, Controller> {
        protected override StudentsController createObj() => new(null);
    }
}
