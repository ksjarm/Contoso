using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass] public class CreateViewStringsTests : StaticTests {
    protected override Type getType() => typeof(CreateViewStrings);
    [TestMethod] public void CreateTitleTest() => Assert.AreEqual("Create", CreateViewStrings.CreateTitle);
}
