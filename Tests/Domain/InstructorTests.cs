using Contoso.Domain;

namespace Tests.Domain {
    [TestClass] public class InstructorTests {
        private Instructor? obj;
        [TestInitialize] public void TestInitialize() => obj = new Instructor();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}