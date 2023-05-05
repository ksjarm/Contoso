using Contoso.Data;

namespace Contoso.Tests.Data;

[TestClass] public class IsoGenderTests : StaticTests {
    protected override Type getType() => typeof(IsoGender);
}