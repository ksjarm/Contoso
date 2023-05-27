using Contoso.Facade.Base;

namespace Contoso.Tests.Facade.Base;
[TestClass] public class DescribedViewTests : AbstractTests<DescribedView, BaseView> {
    private class testClass : DescribedView { }
    protected override DescribedView createObj() => new testClass();
    [TestMethod] public void DescriptionTest() => isNullable<string>("Description");
}