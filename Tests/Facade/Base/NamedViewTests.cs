using Contoso.Facade.Base;

namespace Contoso.Tests.Facade.Base;
[TestClass] public class NamedViewTests : AbstractTests<NamedView, DescribedView> {
    private class testClass : NamedView { }
    protected override NamedView createObj() => new testClass();
    [TestMethod] public void CodeTest() => isNullable<string>("Code");
    [TestMethod] public void NameTest() => isNullable<string>("Name");
}