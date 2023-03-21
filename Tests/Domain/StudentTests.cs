using Contoso.Domain;

namespace Tests.Domain {
    [TestClass] public class StudentTests {
        private Student? obj;
        [TestInitialize] public void TestInitialize() => obj = new Student();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}
