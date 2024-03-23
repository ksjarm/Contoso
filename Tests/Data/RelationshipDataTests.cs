using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data;
[TestClass] public class RelationshipDataTests : SealedTests<RelationshipData, DescribedData> {
    [TestMethod] public void ParentIDTest() => isProperty<int>();
    [TestMethod] public void StudentIDTest() => isProperty<int>();
}