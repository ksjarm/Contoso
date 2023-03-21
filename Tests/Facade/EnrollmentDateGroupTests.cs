using Contoso.Facade;

namespace Tests.Facade {
    [TestClass] public class EnrollmentDateGroupTests {
        private EnrollmentDateGroup? obj;
        [TestInitialize] public void TestInitialize() => obj = new EnrollmentDateGroup();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}
