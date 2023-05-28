using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class InstructorViewTests : SealedTests<InstructorView, PersonView> {
    [TestMethod] public void HireDateTest() => isProperty<DateTime>("Hire Date", "Date");
    [TestMethod] public void OfficeTest() => isNullable<string>("Office");
    [TestMethod] public void CoursesTest() => isProperty<IEnumerable<CourseView>>("Courses");
}
