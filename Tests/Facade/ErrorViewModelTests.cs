using Contoso.Facade;

namespace Tests.Facade {
    [TestClass] public class ErrorViewModelTests {
        private ErrorViewModel? obj;
        [TestInitialize] public void TestInitialize() => obj = new ErrorViewModel();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}
