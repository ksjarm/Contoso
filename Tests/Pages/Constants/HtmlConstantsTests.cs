using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass] public class HtmlConstantsTests : StaticTests {
    protected override Type getType() => typeof(HtmlConstants);
    [TestMethod] public void BoldTitleStartTest() => Assert.AreEqual("<dt class=\"col-sm-2\">", HtmlConstants.BoldTitleStart);
    [TestMethod] public void BoldTitleEndTest() => Assert.AreEqual("</dt>", HtmlConstants.BoldTitleEnd);
    [TestMethod] public void TitleStartTest() => Assert.AreEqual("<dd class=\"col-sm-2\">", HtmlConstants.TitleStart);
    [TestMethod] public void TitleEndTest() => Assert.AreEqual("</dd>", HtmlConstants.TitleEnd);
    [TestMethod] public void DataStartTest() => Assert.AreEqual("<dd class=\"col-sm-10\">", HtmlConstants.DataStart);
    [TestMethod] public void DataEndTest() => Assert.AreEqual("</dd>", HtmlConstants.DataEnd);
    [TestMethod] public void TextDangerTest() => Assert.AreEqual("<text-danger>", HtmlConstants.TextDanger);
}
