using Contoso.Data.Base;

namespace Contoso.Tests.Data.Base {
    [TestClass] public class PersonDataTests : AbstractTests<PersonData, NamedData> {
        private class testClass: PersonData { }
        protected override PersonData createObj() => new testClass();
    }
}
