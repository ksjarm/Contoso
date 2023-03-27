using Contoso.Soft.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Soft.Controllers;
public class InstructorsControllerTests : BaseTests<InstructorsController, Controller> {
    protected override InstructorsController createObj() => new();
}
