using Contoso.Pages.Constants;

namespace Contoso.Tests.Pages.Constants;
[TestClass] public class DatasTests : StaticTests {
    protected override Type type => typeof(Datas);
    [TestMethod] public void TitleTest() => Assert.AreEqual("Title", Datas.Title);
    [TestMethod] public void ItemIDTest() => Assert.AreEqual("ItemID", Datas.ItemID);
    [TestMethod] public void PageTest() => Assert.AreEqual("Page", Datas.Page);
    [TestMethod] public void SortOrderTest() => Assert.AreEqual("SortOrder", Datas.SortOrder);
    [TestMethod] public void PageIndexTest() => Assert.AreEqual("PageIndex", Datas.PageIndex);
    [TestMethod] public void TotalPagesTest() => Assert.AreEqual("TotalPages", Datas.TotalPages);
    [TestMethod] public void CurrentFilterTest() => Assert.AreEqual("CurrentFilter", Datas.CurrentFilter);
}