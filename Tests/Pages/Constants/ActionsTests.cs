using Contoso.Pages.Constants;

namespace Contoso.Tests.Pages.Constants;
[TestClass] public class ActionsTests : StaticTests {
    protected override Type getType() => typeof(Actions);
    [TestMethod] public void EditTest() => Assert.AreEqual("Edit", Actions.Edit);
    [TestMethod] public void CreateTest() => Assert.AreEqual("Create", Actions.Create);
    [TestMethod] public void DeleteTest() => Assert.AreEqual("Delete", Actions.Delete);
    [TestMethod] public void DetailsTest() => Assert.AreEqual("Details", Actions.Details);
    [TestMethod] public void IndexTest() => Assert.AreEqual("Index", Actions.Index);
}
