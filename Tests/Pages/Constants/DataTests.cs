using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass]
public class DataTests : StaticTests {
    protected override Type getType() => typeof(Data);
    [TestMethod] public void TitleTest() => Assert.AreEqual("Title", Data.Title);
    [TestMethod] public void ItemIDTest() => Assert.AreEqual("ItemID", Data.ItemID);
}
