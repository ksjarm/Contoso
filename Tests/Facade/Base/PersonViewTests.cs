using Contoso.Data;
using Contoso.Facade.Base;

namespace Contoso.Tests.Facade.Base;
[TestClass] public class PersonViewTests : AbstractTests<PersonView, NamedView> {
    private class testClass : PersonView { }
    protected override PersonView createObj() => new testClass();
    [TestMethod] public void NameTest() => isNullable<string>("Last Name");
    [TestMethod] public void FirstNameTest() => isNullable<string>("First Name");
    [TestMethod] public void FullNameTest() => isNullable<string>("Full Name");
    [TestMethod] public void GenderTest() => isProperty<IsoGender>("Gender");
    [TestMethod] public void PhotoViewTest() => isNullable<string>("Photo");
    //[TestMethod] public void PhotoFileTest() => isNullable<IFormFile>("Photo File");
}