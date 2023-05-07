using Contoso.Data;

namespace Contoso.Tests.Data;

[TestClass] public class GradeTests : StaticTests {
    protected override Type type => typeof(Grade);
}
