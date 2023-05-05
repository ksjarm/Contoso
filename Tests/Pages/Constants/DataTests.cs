using Contoso.Pages.Constants;

namespace Contoso.Tests.Pages.Constants;
[TestClass] public class DataTests : StaticTests {
    protected override Type getType() => typeof(Datas);
    [TestMethod] public void TitleTest() => Assert.AreEqual("Title", Datas.Title);
    [TestMethod] public void ItemIDTest() => Assert.AreEqual("ItemID", Datas.ItemID);
}