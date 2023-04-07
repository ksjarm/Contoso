using Contoso.Domain;

namespace Tests.Domain;
[TestClass] public class EnrollmentTests : ClassTests<Enrollment, object> {
    [TestMethod] public void EnrollmentIDTest() {
        var i = new Random().Next();
        obj.ID = i;
        Assert.AreEqual(i, obj.ID);
    }
}