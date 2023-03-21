using Contoso.Domain;

namespace Tests.Domain {
    [TestClass] public class CourceAssignmentTests {
        private CourseAssignment? obj;
        [TestInitialize] public void TestInitialize() => obj = new CourseAssignment();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}
