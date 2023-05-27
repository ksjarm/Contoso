using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Base;

namespace Contoso.Tests.Domain;
[TestClass] public class CourseTests : SealedTests<Course, NamedEntity<CourseData>> {
    //[TestMethod] public void CourseIDTest() {
    //    var i = new Random().Next();
    //    obj.ID = i;
    //    Assert.AreEqual(i, obj.ID);
    //}

}
