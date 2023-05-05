using Tests;

namespace Contoso.Tests;
public class SealedTests<TClass, TBaseClass> :
    ClassTests<TClass, TBaseClass> where TClass : new() {
    [TestMethod] public void IsSealed() => Assert.Inconclusive();
}