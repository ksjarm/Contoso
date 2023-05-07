using Contoso.Pages.Constants;

namespace Contoso.Tests.Pages.Constants;
[TestClass]
public class TextsTests : StaticTests {
    protected override Type type => typeof(Texts);
    [TestMethod] public void EditTest() => Assert.AreEqual("Edit", Texts.Edit);
    [TestMethod] public void IndexTest() => Assert.AreEqual("Index", Texts.Index);
    [TestMethod] public void CreateTest() => Assert.AreEqual("Create", Texts.Create);
    [TestMethod] public void DeleteTest() => Assert.AreEqual("Delete", Texts.Delete);
    [TestMethod] public void SaveTest() => Assert.AreEqual("Save", Texts.Save);
    [TestMethod] public void DetailsTest() => Assert.AreEqual("Details", Texts.Details);
    [TestMethod] public void BackToListTest() => Assert.AreEqual("Back to List", Texts.BackToList);
    [TestMethod] public void DeleteQuestionTest() => Assert.AreEqual("Are you sure you want to delete this?", Texts.DeleteQuestion);
}