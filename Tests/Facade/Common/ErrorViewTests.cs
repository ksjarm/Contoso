using Contoso.Facade.Common;

namespace Contoso.Tests.Facade.Common;
[TestClass] public class ErrorViewTests : ClassTests<ErrorView, object> {
    [TestMethod] public void RequestIDTest() => isNullable<string>();
    [TestMethod] public void ShowRequestIDTest() => isReadable<bool>();
}