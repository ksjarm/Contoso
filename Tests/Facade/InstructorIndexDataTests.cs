using Contoso.Facade;

namespace Tests.Facade {
    [TestClass] public class InstructorIndexDataTests {
        private InstructorIndexData? obj;
        [TestInitialize] public void TestInitialize() => obj = new InstructorIndexData();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}
