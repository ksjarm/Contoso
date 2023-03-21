using Contoso.Domain;

namespace Tests.Domain {
    [TestClass] public class OfficeAssignmentTests {
        private OfficeAssignment? obj;
        [TestInitialize] public void TestInitialize() => obj = new OfficeAssignment();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}
