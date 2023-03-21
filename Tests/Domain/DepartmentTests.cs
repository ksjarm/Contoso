using Contoso.Domain;

namespace Tests.Domain {
    [TestClass] public class DepartmentTests {
        private Department? obj;
        [TestInitialize] public void TestInitialize() => obj = new Department();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}