﻿using Contoso.Data.Base;

namespace Contoso.Tests.Data.Base;
[TestClass] public class IEntityTests : StaticTests {
    protected override Type type => typeof(IEntity);
    [TestMethod] public void IDTest() => isInterface<int>();
}
