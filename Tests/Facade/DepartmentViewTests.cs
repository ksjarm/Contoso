using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class DepartmentViewTests : SealedTests<DepartmentView, NamedView> {
    [TestMethod] public void BudgetTest() => isProperty<decimal>();
    [TestMethod] public void StartDateTest() => isProperty<DateTime>("Start Date");
    [TestMethod] public void InstructorIDTest() => isProperty<int>("Instructor");
	[TestMethod] public void InstructorNameTest() => isNullable<string>("Instructor");
}
