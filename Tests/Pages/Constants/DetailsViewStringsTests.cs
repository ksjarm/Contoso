using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass] public class DetailsViewStringsTests : StaticTests {
    protected override Type getType() => typeof(DetailsViewStrings);
    [TestMethod] public void DetailsTitleTest() => Assert.AreEqual("Details", DetailsViewStrings.DetailsTitle);
}
