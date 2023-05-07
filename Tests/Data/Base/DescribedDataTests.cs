using Contoso.Data.Base;

namespace Contoso.Tests.Data.Base; 
[TestClass] public class DescribedDataTests : AbstractTests<DescribedData, BaseData> {
    private class testClass : DescribedData { }
    protected override DescribedData createObj() => new testClass();
    [TestMethod] public void DescriptionTest() => isNullable<string>();

}
