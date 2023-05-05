using Contoso.Domain;
using Contoso.Domain.Base;

namespace Contoso.Tests.Domain;
[TestClass] public class DepartmentTests : ClassTests<Department, NamedEntity> {
     [TestMethod] public void DepartmentIDTest() {
        var i = new Random().Next();
        obj.ID = i;
        Assert.AreEqual(i, obj.ID);
    }
}