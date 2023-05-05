using Contoso.Domain;
using Contoso.Domain.Base;

namespace Tests.Domain;
[TestClass] public class EnrollmentTests : ClassTests<Enrollment, BaseEntity> {
    [TestMethod] public void EnrollmentIDTest() {
        var i = new Random().Next();
        obj.ID = i;
        Assert.AreEqual(i, obj.ID);
    }
}