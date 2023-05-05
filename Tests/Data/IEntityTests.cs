using Contoso.Data;

namespace Contoso.Tests.Data;

[TestClass] public class IEntityTests : StaticTests {
    protected override Type getType() => typeof(IEntity);
}
