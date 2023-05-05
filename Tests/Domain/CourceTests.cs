using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Domain;
[TestClass] public class CourceTests : ClassTests<CourseData, NamedData> {
    [TestMethod] public void CourseIDTest() {
        var i = new Random().Next();
        obj.ID = i;
        Assert.AreEqual(i, obj.ID);
    }
}
