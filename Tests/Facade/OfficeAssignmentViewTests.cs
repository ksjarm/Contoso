using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class OfficeAssignmentViewTests : SealedTests<OfficeAssignmentView, DescribedView> {
    [TestMethod] public void InstructorIDTest() => isProperty<int>("Instructor");
    [TestMethod] public void InstructorNameTest() => isNullable<string>("Instructor");
    [TestMethod] public void LocationTest() => isNullable<string>("Office Location");
}
