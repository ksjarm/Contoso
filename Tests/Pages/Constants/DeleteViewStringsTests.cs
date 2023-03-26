using Contoso.Pages.Constants;

namespace Tests.Pages.Constants;
[TestClass]
public class DeleteViewStringsTests : StaticTests
{
    protected override Type getType() => typeof(DeleteViewStrings);
    [TestMethod] public void DeleteQuestionTest() => Assert.AreEqual("Are you sure you want to delete this?", DeleteViewStrings.DeleteQuestion);
    [TestMethod] public void DeleteTitleTest() => Assert.AreEqual("Delete", DeleteViewStrings.DeleteTitle);
}
