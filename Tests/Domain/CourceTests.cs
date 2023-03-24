using Contoso.Domain;

namespace Tests.Domain
{
    [TestClass] public class CourceTests : ClassTests<Course, object> {
        [TestMethod] public void CourseIDTest() {
            var i = new Random().Next();
            obj.CourseID = i;
            Assert.AreEqual(i, obj.CourseID);
        }
    }
}
