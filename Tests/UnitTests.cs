namespace Contoso.Tests; 
[TestClass] public class UnitTests {
    [TestMethod] public void ExampleTest() => Assert.AreEqual(15, 5 * 3);
    [TestMethod] public void YellowTest() => Assert.Inconclusive();
}