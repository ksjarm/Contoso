using Contoso.Facade.Common;

namespace Contoso.Tests.Facade.Common;
[TestClass] public class AssignedCourseViewTests : ClassTests<AssignedCourseView, object> {
    [TestMethod] public void CourseIDTest() => isProperty<int>();
    [TestMethod] public void TitleTest() => isNullable<string>();
    [TestMethod] public void AssignedTest() => isProperty<bool>();
}