using Contoso.Data;

namespace Tests.Domain;
[TestClass] public class CourceTests : ClassTests<CourseData, object> {
    [TestMethod] public void CourseIDTest() {
        var i = new Random().Next();
        obj.ID = i;
        Assert.AreEqual(i, obj.ID);
    }
}
