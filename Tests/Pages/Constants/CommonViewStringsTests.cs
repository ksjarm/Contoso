using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass]
public class CommonViewStringsTests : StaticTests {
    protected override Type getType() => typeof(CommonViewStrings);
    [TestMethod] public void LayoutTest() => Assert.AreEqual("_Layout", CommonViewStrings.Layout);
    [TestMethod] public void BackToListTest() => Assert.AreEqual("Back to List", CommonViewStrings.BackToList);
    [TestMethod] public void EditTest() => Assert.AreEqual("Edit", CommonViewStrings.Edit);
}
