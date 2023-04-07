//using Contoso.Domain;
//using Contoso.Pages.HtmlHelpers;
//using Microsoft.AspNetCore.Html;
//using System.Linq.Expressions;
//using System.Text.Encodings.Web;

//namespace Tests.Pages.HtmlHelpers;
//[TestClass]
//public class HtmlEditItemTests : StaticTests
//{
//    protected override Type getType() => typeof(HtmlEditItem);
//    [TestMethod]
//    public void ControllerForTest()
//    {
//        var html = HtmlEditItem.EditItem(new HtmlHelperMock<Course>(), (Expression<Func<Course, string>>)(x => x.Title));
//        var b = html as HtmlContentBuilder;
//        Assert.IsNotNull(b);
//        Assert.AreEqual(7, b.Count);
//        var w = new StringWriter();
//        b.WriteTo(w, HtmlEncoder.Default);
//        var s = w.ToString();
//        Assert.AreEqual("<dd class=\"col-sm-2\">LabelFor</dd><dd class=\"col-sm-10\">EditorForValidationMessageFor</dd>", s);
//    }
//}
