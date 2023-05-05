using Contoso.Pages.Constants;

namespace Contoso.Tests.Pages.Constants;
[TestClass]
public class TextsTests : StaticTests {
    protected override Type getType() => typeof(Contoso.Pages.Constants.Texts);
    [TestMethod] public void EditTest() => Assert.AreEqual("Edit", Contoso.Pages.Constants.Texts.Edit);
    [TestMethod] public void IndexTest() => Assert.AreEqual("Index", Contoso.Pages.Constants.Texts.Index);
    [TestMethod] public void CreateTest() => Assert.AreEqual("Create", Contoso.Pages.Constants.Texts.Create);
    [TestMethod] public void DeleteTest() => Assert.AreEqual("Delete", Contoso.Pages.Constants.Texts.Delete);
    [TestMethod] public void SaveTest() => Assert.AreEqual("Save", Contoso.Pages.Constants.Texts.Save);
    [TestMethod] public void DetailsTest() => Assert.AreEqual("Details", Contoso.Pages.Constants.Texts.Details);
    [TestMethod] public void BackToListTest() => Assert.AreEqual("Back to List", Contoso.Pages.Constants.Texts.BackToList);
    [TestMethod] public void DeleteQuestionTest() => Assert.AreEqual("Are you sure you want to delete this?", Contoso.Pages.Constants.Texts.DeleteQuestion);
}