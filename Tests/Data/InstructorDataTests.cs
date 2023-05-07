using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class InstructorDataTests :
    SealedTests<InstructorData, PersonData> {
    [TestMethod] public void HireDateTest() => isProperty<DateTime>();
}
