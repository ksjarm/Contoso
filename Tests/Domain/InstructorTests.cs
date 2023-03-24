using Contoso.Domain;

namespace Tests.Domain
{
    [TestClass] public class InstructorTests : ClassTests<Instructor, Person> {
		[TestMethod] public void InstructorIDTest() {
			var i = new Random().Next();
			obj.ID = i;
			Assert.AreEqual(i, obj.ID);
		}
    }
}