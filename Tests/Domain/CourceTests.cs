using Contoso.Domain;

namespace Tests.Domain {
    [TestClass] public class CourceTests {
        private Course? obj;
        [TestInitialize] public void TestInitialize() => obj = new Course();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
        [TestMethod] public void IsTypeOfTest() => Assert.IsInstanceOfType(obj, typeof(Course));
        [TestMethod] public void CourseIDTest() {
            var i = new Random().Next();
            obj.CourseID = i;
            Assert.AreEqual(i, obj.CourseID);
        }
    }
}
