using Contoso.Facade.Base;

namespace Contoso.Tests.Facade.Base;
[TestClass] public class BaseViewTests : AbstractTests<BaseView, System.Object> {
    private class testClass : BaseView { }
    protected override BaseView createObj() => new testClass();
    [TestMethod] public void IDTest() => isProperty<int>();
    [TestMethod] public void ValidFromTest() => isProperty<DateTime>("Valid from", "Date");
    [TestMethod] public void ValidToTest() => isProperty<DateTime>("Valid to", "Date");
}