using Contoso.Facade;

namespace Tests.Facade {
    [TestClass] public class AssignedCourseDataTests {
        private AssignedCourseData? obj;
        [TestInitialize] public void TestInitialize() => obj = new AssignedCourseData();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}
