using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass] public class LayoutsTests : StaticTests {
    protected override Type getType() => typeof(Layouts);
    [TestMethod] public void DefaultTest() => Assert.AreEqual("_Layout", Layouts.Default);
    [TestMethod] public void DetailsTest() => Assert.AreEqual("_Details", Layouts.Details);
    [TestMethod] public void DeleteTest() => Assert.AreEqual("_Delete", Layouts.Delete);
    [TestMethod] public void EditTest() => Assert.AreEqual("_Edit", Layouts.Edit);
    [TestMethod] public void IndexTest() => Assert.AreEqual("_Index", Layouts.Index);
    [TestMethod] public void CreateTest() => Assert.AreEqual("_Create", Layouts.Create);
}