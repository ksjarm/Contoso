﻿using Contoso.Data;
using Contoso.Data.Base;
using Contoso.Domain;
using Contoso.Domain.Base;

namespace Contoso.Tests.Domain;
[TestClass] public class CourseTests : SealedTests<Course, NewNamedEntity<CourseData>> {
    //[TestMethod] public void CourseIDTest() {
    //    var i = new Random().Next();
    //    obj.ID = i;
    //    Assert.AreEqual(i, obj.ID);
    //}
}
