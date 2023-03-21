using Contoso.Domain;

namespace Tests.Domain {
    [TestClass] public class EnrollmentTests {
        private Enrollment? obj;
        [TestInitialize] public void TestInitialize() => obj = new Enrollment();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}