﻿using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Facade;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;

namespace Contoso.Tests.Soft.Controllers;
[TestClass] public class InstructorsControllerTests : 
    BaseTests<InstructorsController, BaseController<IInstructorsRepo, Instructor, InstructorView>> {
    protected override InstructorsController createObj() => new();
}