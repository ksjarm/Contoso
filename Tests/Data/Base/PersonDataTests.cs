using Contoso.Data;
using Contoso.Data.Base;

namespace Contoso.Tests.Data.Base; 
[TestClass] public class PersonDataTests : AbstractTests<PersonData, NamedData> {
    private class testClass: PersonData { }
    protected override PersonData createObj() => new testClass();
    [TestMethod] public void FirstNameTest() => isNullable<string>();
    [TestMethod] public void GenderTest() => isProperty<IsoGender>();
    [TestMethod] public void PhotoFileTest() => isNullable<string>();
    [TestMethod] public void PhotoFileTypeTest() => isNullable<string>();
}