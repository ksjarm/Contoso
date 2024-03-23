using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class DepartmentDataTests : SealedTests<DepartmentData, NamedData> {
    [TestMethod] public void BudgetTest() => isProperty<decimal>();
    [TestMethod] public void StartDateTest() => isProperty<DateTime>();
    [TestMethod] public void InstructorIDTest() => isProperty<int>();

}
