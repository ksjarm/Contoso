using Contoso.Domain;

namespace Tests.Domain
{
    [TestClass] public class StudentTests : ClassTests<Student, Person> {
		[TestMethod] public void StudentIDTest() {
			var i = new Random().Next();
			obj.ID = i;
			Assert.AreEqual(i, obj.ID);
		}
	}
}
