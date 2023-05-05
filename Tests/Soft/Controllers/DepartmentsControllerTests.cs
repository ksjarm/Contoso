﻿using Contoso.Domain.Repos;
using Contoso.Domain;
using Contoso.Soft.Controllers;
using Contoso.Soft.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Soft.Controllers;
public class DepartmentsControllerTests : 
    BaseTests<DepartmentsController, BaseController<IDepartmentsRepo, Department>> {
    protected override DepartmentsController createObj() => new();
}
