using Contoso.Domain;

namespace Tests.Domain {
    [TestClass] public class GradeTests {
        private Grade? obj;
        [TestInitialize] public void TestInitialize() => obj = new Grade();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}