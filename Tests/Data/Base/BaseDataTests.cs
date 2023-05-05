using Contoso.Data.Base;

namespace Contoso.Tests.Data.Base {
    [TestClass]
    public class BaseDataTests : AbstractTests<BaseData, object> {
        private class testClass : BaseData { }
        protected override BaseData createObj() => new testClass();
        [TestMethod] public void IDTest() => isProperty<int>();
        [TestMethod] public void ValidFromTest() => isProperty<DateTime>();
        [TestMethod] public void ValidToTest() => isProperty<DateTime>();
    }
}
