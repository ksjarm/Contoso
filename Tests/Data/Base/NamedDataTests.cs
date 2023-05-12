using Contoso.Data.Base;

namespace Contoso.Tests.Data.Base;
[TestClass] public class NamedDataTests : AbstractTests<NamedData, DescribedData> {
    private class testClass : NamedData { }
    protected override NamedData createObj() => new testClass();
    [TestMethod] public void NameTest() => isNullable<string>();
    [TestMethod] public void CodeTest() => isNullable<string>();
}
