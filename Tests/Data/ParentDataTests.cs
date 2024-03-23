using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class ParentDataTests : SealedTests<ParentData, PersonData> {
    [TestMethod] public void PhoneNrTest() => isProperty<int>();
}