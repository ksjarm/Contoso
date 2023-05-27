using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class CourseAssignmentViewTests : SealedTests<CourseAssignmentView, DescribedView> {
    [TestMethod] public void InstructorIDTest() => isProperty<int>("Instructor");
    [TestMethod] public void InstructorNameTest() => isNullable<string>("Instructor");
    [TestMethod] public void CourseIDTest() => isProperty<int>("Course");
    [TestMethod] public void CourseNameTest() => isNullable<string>("Course");
}