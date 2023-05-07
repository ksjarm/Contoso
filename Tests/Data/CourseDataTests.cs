using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class CourseDataTests :
    SealedTests<CourseData, NamedData> {
    [TestMethod] public void NumberTest() => isProperty<int>();
    [TestMethod] public void CreditsTest() => isProperty<int>();
    [TestMethod] public void DepartmentIDTest() => isProperty<int>();

}