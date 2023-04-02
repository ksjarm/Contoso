using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass] public class TagsTests : StaticTests {
    protected override Type getType() => typeof(Tags);
    [TestMethod] public void BoldTitleStartTest() => Assert.AreEqual("<dt class=\"col-sm-2\">", Tags.BoldTitleStart);
    [TestMethod] public void BoldTitleEndTest() => Assert.AreEqual("</dt>", Tags.BoldTitleEnd);
    [TestMethod] public void TitleStartTest() => Assert.AreEqual("<dd class=\"col-sm-2\">", Tags.TitleStart);
    [TestMethod] public void TitleEndTest() => Assert.AreEqual("</dd>", Tags.TitleEnd);
    [TestMethod] public void DataStartTest() => Assert.AreEqual("<dd class=\"col-sm-10\">", Tags.DataStart);
    [TestMethod] public void DataEndTest() => Assert.AreEqual("</dd>", Tags.DataEnd);
    [TestMethod] public void TextDangerTest() => Assert.AreEqual("text-danger", Tags.TextDanger);
    [TestMethod] public void GroupStartTest() => Assert.AreEqual("<div class=\"form-group\">", Tags.GroupStart);
    [TestMethod] public void GroupEndTest() => Assert.AreEqual("</dd>", Tags.GroupEnd);
    [TestMethod] public void FormControlTest() => Assert.AreEqual("form-control", Tags.FormControl);
}
