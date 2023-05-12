using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class CourseViewTests :
    SealedTests<CourseView, NamedView> {
    [TestMethod] public void NameTest() => isNullable<string>("Title");
    [TestMethod] public void NumberTest() => isProperty<int>("Number");
    [TestMethod] public void CreditsTest() => isProperty<int>("Credits");
    [TestMethod] public void DepartmentIDTest() => isProperty<int>("Department");
    [TestMethod] public void DepartmentNameTest() => isNullable<string>("Department");
}