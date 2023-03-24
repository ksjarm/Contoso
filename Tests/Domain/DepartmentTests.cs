using Contoso.Domain;

namespace Tests.Domain
{
    [TestClass] public class DepartmentTests : ClassTests<Department, object> {
         [TestMethod] public void DepartmentIDTest() {
            var i = new Random().Next();
            obj.DepartmentID = i;
            Assert.AreEqual(i, obj.DepartmentID);
        }
    }
}