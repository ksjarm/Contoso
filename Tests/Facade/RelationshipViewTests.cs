using Contoso.Facade;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade;
[TestClass] public class RelationshipViewTests : SealedTests<RelationshipView, DescribedView> {
    [TestMethod] public void ParentIDTest() => isProperty<int>("Parent");
    [TestMethod] public void ParentNameTest() => isNullable<string>("Parent");
    [TestMethod] public void StudentIDTest() => isProperty<int>("Student");
    [TestMethod] public void StudentNameTest() => isNullable<string>("Student");
}