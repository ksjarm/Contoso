﻿using Contoso.Soft.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Soft.Controllers;
public class HomeControllerTests : BaseTests<HomeController, Controller> {
    protected override HomeController createObj() => new(null);
}
