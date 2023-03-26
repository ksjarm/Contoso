using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass]
public class ViewDataStringsTests : StaticTests
{
    protected override Type getType() => typeof(ViewDataStrings);
    [TestMethod] public void TitleTest() => Assert.AreEqual("Title", ViewDataStrings.Title);
    [TestMethod] public void CaptionTest() => Assert.AreEqual("Caption", ViewDataStrings.Caption);
    [TestMethod] public void ItemIDTest() => Assert.AreEqual("ItemID", ViewDataStrings.ItemID);
}
