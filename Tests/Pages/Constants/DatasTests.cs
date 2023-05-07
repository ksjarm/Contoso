using Contoso.Pages.Constants;

namespace Contoso.Tests.Pages.Constants;
[TestClass] public class DatasTests : StaticTests {
    protected override Type type => typeof(Datas);
    [TestMethod] public void TitleTest() => Assert.AreEqual("Title", Datas.Title);
    [TestMethod] public void ItemIDTest() => Assert.AreEqual("ItemID", Datas.ItemID);
}